namespace TestScriptRunner.Commands
{
    public class DoubleClickCommand : CommandBase
    {
        public DoubleClickCommand(Statement statement) : base(statement)
        {
        }

        public override CommandExecutionResult Execute(CommandExecutionContext context)
        {
            return CommandExecutionResult.SuccessCommand;
        }
    }
}