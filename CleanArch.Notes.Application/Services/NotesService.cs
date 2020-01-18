using CleanArch.Notes.Application.Interfaces;
using CleanArch.Notes.Domain.Models;
using System;
using System.Collections.Generic;

namespace CleanArch.Notes.Application.Services
{
    public class NotesService : INotesService
    {
        private readonly INotesRepository notesRepository;

        public NotesService(INotesRepository notesRepository)
        {
            this.notesRepository = notesRepository;
        }

        public void AddNote(Note note)
        {
            notesRepository.AddNote(note);
        }

        public IEnumerable<Note> GetNotes()
        {
            return notesRepository.GetNotes();
        }
    }
}
