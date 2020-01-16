using CleanArch.Domain.Core.Events;
using System.Threading.Tasks;

namespace CleanArch.Domain.Core.Bus
{
    public interface IEventHandler<TEvent> : IEventHandler
        where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {
    }
}
