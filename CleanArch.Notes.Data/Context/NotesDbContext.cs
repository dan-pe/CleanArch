using CleanArch.Notes.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Notes.Data.Context
{
    public class NotesDbContex : DbContext
    {
        public NotesDbContex(DbContextOptions options) : base(options)   
        {
        }

        public DbSet<Note> Notes { get; set; }
    }
}
