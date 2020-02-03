using System;
using System.Linq;

namespace TestScriptRunner
{
    public class SyntaxErrorException : Exception
    {
        public int Index { get; }
        public int Line { get; }
        public string FileName { get; }

        public SyntaxErrorException(string message, string fileName) : base(message)
        {
            FileName = fileName;
        }

        public SyntaxErrorException(int index, int line, string source, string fileName) : this($"Invalid syntax at column {index} line {line}: {FromSource(source, line)} in '{fileName}'", fileName)
        {
            Index = index;
            Line = line;
            FileName = fileName;
        }


        private static string FromSource(string source, int line)
        {
            var errorLineContent = source?.Split('\n')?.Skip(line + 1)?.FirstOrDefault();
            return errorLineContent?.Trim();
        }
    }
}