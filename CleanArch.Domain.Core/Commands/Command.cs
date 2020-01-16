using CleanArch.Domain.Core.Events;
using System;

namespace CleanArch.Domain.Core.Commands
{
    public class Command : Message
    {
        public DateTime Timestamp { get; set; }

        public Command()
        {
            Timestamp = DateTime.Now;
        }
    }
}
