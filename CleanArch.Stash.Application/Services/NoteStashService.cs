using CleanArch.Stash.Application.Interfaces;
using CleanArch.Stash.Domain.Interfaces;
using CleanArch.Stash.Domain.Models;
using System.Collections.Generic;

namespace CleanArch.Stash.Application.Services
{
    public class NoteStashService : INoteStashService
    {
        private readonly INoteStashRepository noteStashRepository;

        public NoteStashService(INoteStashRepository noteStashRepository)
        {
            this.noteStashRepository = noteStashRepository;
        }

        public IEnumerable<StashNote> GetStashNotes()
        {
            return noteStashRepository.GetStashedNotes();
        }
    }
}
