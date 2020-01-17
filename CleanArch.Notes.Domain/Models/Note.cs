using System;

namespace CleanArch.Notes.Domain.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
    }
}
