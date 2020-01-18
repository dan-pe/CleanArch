using CleanArch.Domain.Core.Bus;
using CleanArch.Stash.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Stash.Domain.EventHandlers
{
    public class NoteCreatedEventHandler : IEventHandler<NoteCreatedEvent>
    {
        private readonly INoteStashRepository noteStashRepository;

        public NoteCreatedEventHandler(INoteStashRepository noteStashRepository)
        {
            this.noteStashRepository = noteStashRepository;
        }

        public Task Handle(NoteCreatedEvent e)
        {
            var stashNote = new Models.StashNote(e.Content, e.Header, e.CreationTime);
            noteStashRepository.AddStashNote(stashNote);

            return Task.CompletedTask;
        }
    }
}
