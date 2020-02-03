namespace TestScriptRunner.Commands
{
    public class WaitCommand : CommandBase
    {
        public WaitCommand(Statement statement) : base(statement)
        {
        }

        public override CommandExecutionResult Execute(CommandExecutionContext context)
        {
            return CommandExecutionResult.SuccessCommand;
        }
    }
}