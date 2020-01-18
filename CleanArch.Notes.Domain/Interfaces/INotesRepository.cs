using CleanArch.Notes.Domain.Models;
using System.Collections.Generic;

namespace CleanArch.Notes.Application.Interfaces
{
    public interface INotesRepository
    {
        IEnumerable<Note> GetNotes();

        void AddNote(Note note);
    }
}
