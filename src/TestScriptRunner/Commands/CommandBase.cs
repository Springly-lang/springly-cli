using System;

namespace TestScriptRunner.Commands
{
    public abstract class CommandBase
    {
        public static readonly NoOpCommand NoOp = new NoOpCommand();

        public sealed class NoOpCommand : CommandBase
        {
            public NoOpCommand() : base(null)
            {
            }

            public override CommandExecutionResult Execute(CommandExecutionContext context)
            {
                // No Ops
                return CommandExecutionResult.SuccessCommand;
            }
        }


        public CommandBase(Statement statement)
        {
            Statement = statement;
        }

        public Statement Statement { get; }

        public abstract CommandExecutionResult Execute(CommandExecutionContext context);

        public static Exception ThrowTokenExpected(TokenType expectedToken, TokenType actualToken, string fileName)
        {
            return new SyntaxErrorException($"'{expectedToken}' was expected but '{actualToken}' was found.", fileName);
        }

        public static Exception ThrowTokenExpected(TokenType expectedToken, string fileName)
        {
            return new SyntaxErrorException($"'{expectedToken}' was expected but was not found.", fileName);
        }
    }
}