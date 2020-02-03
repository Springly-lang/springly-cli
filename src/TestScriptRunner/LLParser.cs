using System.Collections.Generic;
using System.Linq;

namespace TestScriptRunner
{
    public class LLParser
    {
        public static IEnumerable<Statement> Parse(TestCaseSourceFile file, IEnumerable<Token> tokens)
        {
            return tokens.GroupBy(x => x.Line).Select(x => new Statement(file, x));
        }
    }
}