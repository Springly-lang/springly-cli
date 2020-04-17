using System;

namespace SpringlyLang.Driver
{
#pragma warning disable RCS1194 // Implement exception constructors.
    public class ExpectationNotSatisfiedException : Exception
#pragma warning restore RCS1194 // Implement exception constructors.
    {
        public ExpectationNotSatisfiedException(string message, int line, int column, string fileName) : this(message, null, line, column, fileName)
        {
        }

        public ExpectationNotSatisfiedException(string message, Exception innerException, int line, int column, string fileName) : base(message, innerException)
        {
            Line = line;
            Column = column;
            FileName = fileName;
        }

        public int Line { get; }
        public int Column { get; }
        public string FileName { get; }
    }
}
