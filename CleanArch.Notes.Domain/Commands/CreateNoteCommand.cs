using CleanArch.Domain.Core.Commands;
using System;

namespace CleanArch.Notes.Domain.Commands
{
    public class CreateNoteCommand : Command
    {
        public string Header { get; protected set; }
        public string Content { get; protected set; }
        public DateTime CreationTime { get; protected set; }

        public CreateNoteCommand(string header, string content, DateTime creationTime)
        {
            Header = header;
            Content = content;
            CreationTime = creationTime;
        }
    }
}
