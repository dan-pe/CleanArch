using CleanArch.Domain.Core.Events;
using System;

namespace CleanArch.Notes.Domain.Events
{
    public class NoteCreatedEvent : Event
    {
        public string Header { get; protected set; }
        public string Content { get; protected set; }
        public DateTime CreationTime { get; protected set; }

        public NoteCreatedEvent(string header, string content)
        {
            Header = header;
            Content = content;
            CreationTime = DateTime.Now;
        }
    }
}
