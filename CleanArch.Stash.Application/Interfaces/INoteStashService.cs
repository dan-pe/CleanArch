using CleanArch.Stash.Domain.Models;
using System.Collections.Generic;

namespace CleanArch.Stash.Application.Interfaces
{
    public interface INoteStashService
    {
        IEnumerable<StashNote> GetStashNotes();
    }
}
