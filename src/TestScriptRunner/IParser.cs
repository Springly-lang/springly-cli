using System.Collections.Generic;

namespace SpringlyLang
{
    public interface IParser
    {
        IEnumerable<Statement> Parse(TestCaseSourceFile file, IEnumerable<Token> tokens);
    }
}