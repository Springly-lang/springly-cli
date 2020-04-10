using Irony.Parsing;
using System;

namespace TestScriptRunner.Language
{
    public class DefaultNonTerminal : NonTerminal
    {
        public DefaultNonTerminal(string name, Type nodeType) : base(name, nodeType)
        {
            AstConfig.DefaultNodeCreator = () => Activator.CreateInstance(nodeType);
        }
    }

    public class DefaultIdentifierTerminal : IdentifierTerminal
    {
        public DefaultIdentifierTerminal(string name, Type nodeType) : base(name)
        {
            AstConfig.DefaultNodeCreator = () => Activator.CreateInstance(nodeType);
        }
    }
}
