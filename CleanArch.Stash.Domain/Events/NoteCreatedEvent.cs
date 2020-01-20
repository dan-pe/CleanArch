using CleanArch.Domain.Core.Events;
using System;

namespace CleanArch.Stash.Domain.EventHandlers
{
    public class NoteCreatedEvent : Event
    {
        public NoteCreatedEvent()
        {
        }

        public string Header { get; protected set; }
        public string Content { get; protected set; }
        public DateTime CreationTime { get; protected set; }
    }
}
