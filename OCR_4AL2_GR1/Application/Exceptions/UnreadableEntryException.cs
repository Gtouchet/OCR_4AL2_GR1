using System;

namespace OCR_4AL2_GR1.Application.Exceptions
{
    public class UnreadableEntryException : Exception
    {
        public UnreadableEntryException(int line) : base($"Error: unreadable entry at line {line}") { }
    }
}
