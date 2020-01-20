using CleanArch.Domain.Core.Bus;
using CleanArch.Notes.Application.Interfaces;
using CleanArch.Notes.Domain.Commands;
using CleanArch.Notes.Domain.Models;
using System.Collections.Generic;

namespace CleanArch.Notes.Application.Services
{
    public class NotesService : INotesService
    {
        private readonly INotesRepository notesRepository;
        private readonly IEventBus eventBus;

        public NotesService(INotesRepository notesRepository, IEventBus eventBus)
        {
            this.notesRepository = notesRepository;
            this.eventBus = eventBus;
        }

        public void StashNote(Note note)
        {
            var noteCreatedCommand = new CreateNoteCommand(note.Header, note.Content, note.CreationTime);

            eventBus.SendCommand(noteCreatedCommand);

        }

        public IEnumerable<Note> GetNotes()
        {
            return notesRepository.GetNotes();
        }
    }
}
