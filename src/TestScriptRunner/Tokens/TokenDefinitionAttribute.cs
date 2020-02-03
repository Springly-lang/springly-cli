using System;

namespace TestScriptRunner
{
    public class TokenDefinitionAttribute : Attribute
    {
        public TokenDefinitionAttribute(string pattern)
        {
            Pattern = pattern;
        }

        public string Pattern { get; }
    }
}