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

        public IEnumerable<Note> GetNotes()
        {
            return notesRepository.GetNotes();
        }
    }
}
