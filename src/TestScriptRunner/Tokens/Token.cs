using System.Diagnostics;

namespace TestScriptRunner
{
    [DebuggerDisplay("{TokenType}, {Value}, Column={Column}, Line={Line}")]
    public class Token
    {
        public Token(TokenType tokenType, string value, int line, int column)
        {
            TokenType = tokenType;
            Value = value;
            Line = line;
            Column = column;
        }

        public TokenType TokenType { get; }
        public string Value { get; }
        public int Line { get; }
        public int Column { get; }
    }
}