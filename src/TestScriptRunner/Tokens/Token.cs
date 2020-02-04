using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using TestScriptRunner.Utils;

namespace TestScriptRunner
{
    [DebuggerDisplay("{TokenType}, {Value}, Column={Column}, Line={Line}")]
    public class Token
    {
        public static readonly IEnumerable<TokenType> Keywords = ReflectionHelpers.GetTokenTypeKeywords();

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

        public bool IsKeyword => Keywords.Any(k => k == TokenType);

        public override string ToString()
        {
            if (IsKeyword)
            {
                return TokenType.ToString().ToLower();
            }

            if (TokenType == TokenType.StringLiteral)
            {
                return $"\"{Value}\"";
            }

            return Value;
        }
    }
}