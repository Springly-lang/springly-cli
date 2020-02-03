using System.Collections.Generic;
using System.Diagnostics;

namespace TestScriptRunner
{
    [DebuggerDisplay("{Display}")]
    public class Statement
    {
        public Statement(TestCaseSourceFile file, IEnumerable<Token> tokens)
        {
            File = file;
            Tokens = tokens;
        }

        public TestCaseSourceFile File { get; }

        public IEnumerable<Token> Tokens { get; }

        private string Display => string.Join(' ', Tokens.Select(t => t.TokenType.ToString()));
    }
}