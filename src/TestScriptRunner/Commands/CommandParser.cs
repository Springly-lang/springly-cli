using System;
using System.Linq;

namespace TestScriptRunner.Commands
{
    public interface ICommandParser
    {
        IStartedCommandParser StartsWith(TokenType tokenType);
    }

    public interface IStartedCommandParser
    {
        IStartedCommandParser WithOptionalFollowing(TokenType tokenType);

        IStartedCommandParser WithRequiredFollowing(TokenType tokenType);

        IStartedCommandParser WithValue(TokenType literal, Action<string> handler);

        IStartedCommandParser WithValue(TokenType literal, Action<long> handler);
    }

    public class CommandParser : ICommandParser, IStartedCommandParser
    {
        public static ICommandParser Create(Statement statement)
        {
            return new CommandParser(statement);
        }

        private int _currentPosition = 0;

        private CommandParser(Statement statement)
        {
            Statement = statement;
        }

        public Statement Statement { get; }

        public IStartedCommandParser StartsWith(TokenType tokenType)
        {
            if (_currentPosition != 0)
            {
                throw new InvalidOperationException("StartWith must be called first.");
            }

            Ensure(tokenType, _currentPosition++, false);
            return this;
        }

        public IStartedCommandParser WithOptionalFollowing(TokenType tokenType)
        {
            Ensure(tokenType, _currentPosition++, true);
            return this;
        }

        public IStartedCommandParser WithRequiredFollowing(TokenType tokenType)
        {
            Ensure(tokenType, _currentPosition++, false);
            return this;
        }

        public IStartedCommandParser WithValue(TokenType literal, Action<string> handler)
        {
            Ensure(literal, _currentPosition++, true);
            return this;
        }

        public IStartedCommandParser WithValue(TokenType literal, Action<long> handler)
        {
            Ensure(literal, _currentPosition++, true);
            return this;
        }

        private (int newPosition, bool isMatched, string value) Ensure(TokenType tokenType, int position, bool optional)
        {
            var token = Statement.Tokens.ElementAt(position);
            var isMatched = token.TokenType == tokenType;
            if (!isMatched && !optional)
            {
                throw new SyntaxErrorException(token.Column, token.Line, "", Statement.File.FileName);
            }

            return (position++, isMatched, token.Value);
        }
    }
}