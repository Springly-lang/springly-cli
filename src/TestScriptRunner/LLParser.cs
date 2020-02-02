using System;
using System.Collections.Generic;
using System.Linq;

namespace TestScriptRunner
{
    public class LLParser
    {
        public static IEnumerable<Token> Parse(IEnumerable<Token> tokens)
        {
            var parsedTokens = IgnoreWhiteSpace(tokens);
            parsedTokens = ExpectOneOrMoreUseCommands(parsedTokens);
            parsedTokens = IgnoreWhiteSpace(tokens);
            parsedTokens = ExpectOneOrMoreTestCase(parsedTokens);
            return parsedTokens;
        }

        private static IEnumerable<Token> ExpectOneOrMoreTestCase(IEnumerable<Token> parsedTokens)
        {
            var skipEmptyTokens = true;
            var toReturn = new List<Token>();
            foreach (var token in parsedTokens)
            {
                if (skipEmptyTokens && (token.TokenType == TokenType.WhiteSpace || token.TokenType == TokenType.NewLine))
                {
                    continue;
                }

                skipEmptyTokens = false;
                toReturn.Add(token);
            }

            return toReturn;
        }

        private static IEnumerable<Token> ExpectOneOrMoreUseCommands(IEnumerable<Token> parsedTokens)
        {
            var useToken = parsedTokens.ElementAt(0);
            if (useToken.TokenType != TokenType.Use)
                throw new SyntaxErrorException(useToken.Column, useToken.Line, TokenType.Use, useToken.TokenType);

            yield return useToken;

            foreach (var token in parsedTokens.Skip(1))
                if (token.TokenType == TokenType.WhiteSpace)
                    continue;
        }

        private static IEnumerable<Token> IgnoreWhiteSpace(IEnumerable<Token> tokens)
        {
            throw new NotImplementedException();
        }
    }

    public class TreeNode
    {
        public Token Token { get; set; }

        public TreeNode Left { get; set; }

        public TreeNode Right { get; set; }
    }
}