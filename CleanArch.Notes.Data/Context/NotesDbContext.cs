using CleanArch.Notes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Notes.Data.Context
{
    public class NotesDbContext : DbContext
    {
        public NotesDbContext(DbContextOptions options) : base(options)   
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}
