using CleanArch.Domain.Core.Bus;
using CleanArch.Notes.Domain.Commands;
using CleanArch.Notes.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Notes.Domain.CommandHandlers
{
    public class CreateNoteCommandHandler : IRequestHandler<CreateNoteCommand, bool>
    {
        public readonly IEventBus bus;

        public CreateNoteCommandHandler(IEventBus bus)
        {
            this.bus = bus;
        }

        public Task<bool> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
        {
            var noteCreatedEvent = new NoteCreatedEvent(
                request.Header,
                request.Content);

            bus.Publish(noteCreatedEvent);

            return Task.FromResult(true);
        }
    }
}
