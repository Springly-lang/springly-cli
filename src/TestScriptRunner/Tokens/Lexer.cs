using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace TestScriptRunner
{
    public class Lexer : ILexer
    {
        private static string GetTokenTypePattern(TokenType tokenType)
        {
            var enumMember = typeof(TokenType).GetMember(tokenType.ToString())[0];
            var enumAttr = enumMember.GetCustomAttributes(typeof(TokenDefinitionAttribute), false)
                            .Select(x => x as TokenDefinitionAttribute)
                            .FirstOrDefault();
            return enumAttr?.Pattern;
        }

        public IEnumerable<Token> Tokenize(TestCaseSourceFile file)
        {
            var script = file.Content;
            var tokens = new List<Token>();
            if (string.IsNullOrWhiteSpace(script))
            {
                return Enumerable.Empty<Token>();
            }

            var commands = script.Split('\n', StringSplitOptions.None)
                            .Select(command => command.Trim())
                            .ToArray();

            var tokenTypeList = (TokenType[])Enum.GetValues(typeof(TokenType));
            var definitions = tokenTypeList.OrderBy(tokenType => (int)tokenType).ToDictionary(tokenType => tokenType, GetTokenTypePattern);

            var lineNumber = 1;
            var nextIndex = 0;

            var remaining = script;
            while (remaining.Length > 0)
            {
                var matchFound = false;

                foreach (var def in definitions)
                {
                    var match = Regex.Match(remaining, def.Value);
                    if (match.Success)
                    {
                        var value = match.Groups["value"]?.Value;
                        var token = new Token(def.Key, value, lineNumber, nextIndex + match.Index);
                        tokens.Add(token);
                        nextIndex += match.Length;

                        if (token.TokenType == TokenType.NewLine)
                        {
                            lineNumber++;
                            nextIndex = 0;
                        }

                        if (match.Length <= remaining.Length)
                        {
                            remaining = remaining.Substring(match.Length);
                        }

                        matchFound = true;
                        break;
                    }
                }

                if (!matchFound)
                {
                    throw new SyntaxErrorException(nextIndex, lineNumber, script, file.FileName);
                }
            }

            return new ReadOnlyCollection<Token>(tokens.Where(x => x.TokenType != TokenType.WhiteSpace).ToList());
        }
    }
}