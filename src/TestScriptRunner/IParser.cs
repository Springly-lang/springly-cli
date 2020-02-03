using System.Collections.Generic;

namespace TestScriptRunner
{
    public interface IParser
    {
        IEnumerable<Statement> Parse(TestCaseSourceFile file, IEnumerable<Token> tokens);
    }
}