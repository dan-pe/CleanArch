using System;

namespace CleanArch.Stash.Domain.Models
{
    public class StashNote
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }

        public StashNote(string header, string content, DateTime creationTime)
        {
            Header = header;
            Content = content;
            CreationTime = creationTime;
        }
    }
}
