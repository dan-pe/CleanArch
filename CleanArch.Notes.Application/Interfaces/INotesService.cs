using CleanArch.Notes.Domain.Models;
using System.Collections.Generic;

namespace CleanArch.Notes.Application.Interfaces
{
    public interface INotesService
    {
        IEnumerable<Note> GetNotes();
    }
}
