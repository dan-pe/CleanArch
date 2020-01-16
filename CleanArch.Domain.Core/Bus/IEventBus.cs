using CleanArch.Domain.Core.Commands;
using CleanArch.Domain.Core.Events;
using System.Threading.Tasks;

namespace CleanArch.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T publishEvent) where T : Event;

        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}
