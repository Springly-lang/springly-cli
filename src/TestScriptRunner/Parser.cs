using System.Collections.Generic;
using System.Linq;

namespace SpringlyLang
{
    public class Parser : IParser
    {
        public IEnumerable<Statement> Parse(TestCaseSourceFile file, IEnumerable<Token> tokens)
        {
            return tokens.Where(x => x.TokenType != TokenType.WhiteSpace && x.TokenType != TokenType.Comment)
            .GroupBy(x => x.Line).Select(x => new Statement(file, x));
        }
    }
}