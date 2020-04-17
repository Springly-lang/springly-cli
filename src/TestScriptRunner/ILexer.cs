using System.Collections.Generic;

namespace SpringlyLang
{
    public interface ILexer
    {
        IEnumerable<Token> Tokenize(TestCaseSourceFile file);
    }
}