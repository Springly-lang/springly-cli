namespace TestScriptRunner.Commands
{
    public class ResizeCommand : CommandBase
    {
        public ResizeCommand(Statement statement) : base(statement)
        {
        }

        public override CommandExecutionResult Execute(CommandExecutionContext context)
        {
            return CommandExecutionResult.SuccessCommand;
        }
    }
}