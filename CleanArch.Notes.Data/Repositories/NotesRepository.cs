using CleanArch.Notes.Application.Interfaces;
using CleanArch.Notes.Data.Context;
using CleanArch.Notes.Domain.Models;
using System.Collections.Generic;

namespace CleanArch.Notes.Data.Repositories
{
    public class NotesRepository : INotesRepository
    {
        private readonly NotesDbContex ctx;

        public NotesRepository(NotesDbContex ctx)
        {
            this.ctx = ctx;
        }

        public IEnumerable<Note> GetNotes()
        {
            return ctx.Notes;
        }
    }
}
