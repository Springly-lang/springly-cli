namespace TestScriptRunner.Commands
{
    public class SelectCommand : CommandBase
    {
        public SelectCommand(Statement statement) : base(statement)
        {
        }

        public override CommandExecutionResult Execute(CommandExecutionContext context)
        {
            return CommandExecutionResult.SuccessCommand;
        }
    }
}