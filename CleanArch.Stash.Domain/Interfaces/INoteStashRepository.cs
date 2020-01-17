using CleanArch.Stash.Domain.Models;
using System.Collections.Generic;

namespace CleanArch.Stash.Domain.Interfaces
{
    public interface INoteStashRepository
    {
        IEnumerable<StashNote> GetStashedNotes();
    }
}
