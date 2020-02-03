using System.Collections.Generic;

namespace TestScriptRunner
{
    public interface ILexer
    {
        IEnumerable<Token> Tokenize(TestCaseSourceFile file);
    }
}