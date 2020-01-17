using System;

namespace CleanArch.Notes.Domain.Models
{
    public class Note
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; protected set; }
    }
}
