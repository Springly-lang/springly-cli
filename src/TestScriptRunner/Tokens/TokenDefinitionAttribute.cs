using System;

namespace TestScriptRunner
{
    public class TokenDefinitionAttribute : Attribute
    {
        public TokenDefinitionAttribute(string pattern, bool isKeyword)
        {
            Pattern = pattern;
            IsKeyword = isKeyword;
        }

        public string Pattern { get; }
        public bool IsKeyword { get; }
    }
}