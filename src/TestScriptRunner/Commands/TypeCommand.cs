namespace TestScriptRunner.Commands
{
    public class TypeCommand : CommandBase
    {
        public TypeCommand(Statement statement) : base(statement)
        {
        }

        public override CommandExecutionResult Execute(CommandExecutionContext context)
        {
            return CommandExecutionResult.SuccessCommand;
        }
    }
}