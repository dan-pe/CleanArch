using CleanArch.Stash.Domain.Interfaces;
using CleanArch.Stash.Domain.Models;
using System.Collections.Generic;

namespace CleanArch.Stash.Data.Context
{
    public class NoteStashRepository : INoteStashRepository
    {
        private readonly NoteStashDbContext ctx;

        public NoteStashRepository(NoteStashDbContext ctx)
        {
            this.ctx = ctx;
        }


        public IEnumerable<StashNote> GetStashedNotes()
        {
            return ctx.StashNotes;
        }
    }
}
