using CleanArch.Domain.Core.Bus;
using CleanArch.Domain.Core.Commands;
using CleanArch.Domain.Core.Events;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infrastructure.Bus
{
    public class MessageBus : IEventBus
    {
        private readonly IMediator mediator;
        private readonly IServiceScopeFactory serviceScopeFactory;
        private readonly Dictionary<string, List<Type>> handlers;
        private readonly List<Type> eventTypes;

        public MessageBus(IMediator mediator, IServiceScopeFactory scopeFactory)
        {
            this.mediator = mediator;
            this.serviceScopeFactory = scopeFactory;
            handlers = new Dictionary<string, List<Type>>();
            eventTypes = new List<Type>();
        }

        public void Publish<T>(T publishEvent) where T : Event
        {
            var factory = new ConnectionFactory { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // Routing will be based on the EventName
                var eventName = publishEvent.GetType().Name;

                channel.QueueDeclare(eventName, false, false, false, null);

                var messageBody = JsonConvert.SerializeObject(publishEvent);
                var body = Encoding.UTF8.GetBytes(messageBody);

                channel.BasicPublish("", eventName, null, body);
            }
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return mediator.Send(command);
        }

        public void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>
        {
            var eventType = typeof(T);
            var eventName = eventType.Name;
            var handlerType = typeof(TH);

            if (!eventTypes.Contains(eventType))
            {
                eventTypes.Add(eventType);
            }

            if (!handlers.ContainsKey(eventName))
            {
                handlers.Add(eventType.Name, new List<Type>());
            }

            if (handlers[eventName].Any(e => e.GetType() == handlerType))
            {
                throw new ArgumentException($"Handler {handlerType.Name} is already registered for '{eventName}'", nameof(handlerType));
            }

            handlers[eventName].Add(typeof(TH));

            Consume<T>();
        }

        private void Consume<T>() where T : Event
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost",
                DispatchConsumersAsync = true
            };

            var connection = connectionFactory.CreateConnection();
            var channel = connection.CreateModel();
            var eventName = typeof(T).Name;

            channel.QueueDeclare(eventName, false, false, false, null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;

            channel.BasicConsume(eventName, true, consumer);
        }

        private async Task Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var eventName = e.RoutingKey;
            var message = Encoding.UTF8.GetString(e.Body);

            try
            {
                await ProcessEvent(eventName, message).ConfigureAwait(false);
            }
            catch (Exception)
            {
                // log exception
            }
        }

        private async Task ProcessEvent(string eventName, string message)
        {
            if (handlers.ContainsKey(eventName))
            {
                using (var scope = serviceScopeFactory.CreateScope())
                {
                    var subscriptions = handlers[eventName];
                    foreach (var subscription in subscriptions)
                    {
                        var handler = scope.ServiceProvider.GetService(subscription);
                        var eventType = eventTypes.SingleOrDefault(t => t.Name == eventName);
                        var @event = JsonConvert.DeserializeObject(message, eventType);
                        var concreteType = typeof(IEventHandler<>).MakeGenericType(eventType);

                        await (Task)concreteType.GetMethod("Handle").Invoke(handler, new object[] { @event });
                    }
                }
            }
        }
    }
}
