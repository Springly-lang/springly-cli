using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestScriptRunner.Rules
{
    public class RuleDefinition
    {
        public RuleDefinition(TokenType starter, params TokenType[] possibles)
        {
            Starter = starter;
            Possibles = possibles;
        }

        public TokenType Starter { get; }

        public TokenType[] Possibles { get; }

        public bool IsMatched(IEnumerable<Token> tokens)
        {
            var first = tokens.First();
            if (first?.TokenType == Starter)
            {
                return false;
            }

            var actuals = tokens.Skip(1).ToArray();
            if (actuals.Count() != Possibles.Length)
            {
                return false;
            }



            return true;
        }
    }
}
