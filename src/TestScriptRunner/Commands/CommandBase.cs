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

        public virtual CommandExecutionResult Execute(CommandExecutionContext context)
        {
            return CommandExecutionResult.SuccessCommand;
        }
    }

    public class CommandExecutionResult
    {
        public static readonly CommandExecutionResult SuccessCommand = new CommandExecutionResult(true, null);

        public CommandExecutionResult(bool success, string[] errorMessages)
        {
            Success = success;
            ErrorMessages = errorMessages;
        }

        public string[] ErrorMessages { get; }

        public bool Success { get; }
    }
}