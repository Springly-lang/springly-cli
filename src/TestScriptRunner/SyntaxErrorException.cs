using System;
using System.Linq;

namespace TestScriptRunner
{
    public class SyntaxErrorException : Exception
    {
        public int Index { get; }
        public int Line { get; }

        public SyntaxErrorException(int index, int line, string source, string fileName) : base($"Invalid syntax at column {index} line {line}: {FromSource(source, line)} in '{fileName}'")
        {
            Index = index;
            Line = line;
        }

        public SyntaxErrorException(int index, int line, TokenType expectedTokenType, TokenType actualTokenType)
            : base($"Invalid Syntax at {index} line {line}. '{expectedTokenType}' was expected but '{actualTokenType}' was found.")
        {
            Index = index;
            Line = line;
        }

        private static string FromSource(string source, int line)
        {
            var errorLineContent = source?.Split('\n')?.Skip(line + 1)?.FirstOrDefault();
            return errorLineContent?.Trim();
        }
    }
}