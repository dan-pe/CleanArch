using CleanArch.Notes.Application.Interfaces;
using CleanArch.Notes.Data.Context;
using CleanArch.Notes.Domain.Models;
using System.Collections.Generic;

namespace CleanArch.Notes.Data.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private readonly NotesDbContext ctx;

        public NotesRepository(NotesDbContext ctx)
        {
            this.ctx = ctx;
        }

        public void AddNote(Note note)
        {
            ctx.Add(note);
            ctx.SaveChanges();
        }

        public IEnumerable<Note> GetNotes()
        {
            return ctx.Notes;
        }
    }
}
