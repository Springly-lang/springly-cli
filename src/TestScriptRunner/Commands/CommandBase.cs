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
                return CommandExecutionResult.Empty;
            }
        }


        public CommandBase(Statement statement)
        {
            Statement = statement;
        }

        public Statement Statement { get; }

        public virtual CommandExecutionResult Execute(CommandExecutionContext context)
        {
            return CommandExecutionResult.Empty;
        }
    }

    public class CommandExecutionResult
    {
        public static readonly CommandExecutionResult Empty = new CommandExecutionResult();
    }
}