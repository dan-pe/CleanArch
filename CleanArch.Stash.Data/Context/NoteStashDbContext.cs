using CleanArch.Stash.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Stash.Data.Context
{
    public class NoteStashDbContext : DbContext
    {
        public NoteStashDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<StashNote> StashNotes { get; set; }
    }
}
