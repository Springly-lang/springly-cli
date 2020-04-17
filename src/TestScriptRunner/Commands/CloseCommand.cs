namespace SpringlyLang.Commands
{
    public class CloseCommand : CommandBase
    {
        public CloseCommand(Statement statement) : base(statement)
        {
        }

        public override CommandExecutionResult Execute(CommandExecutionContext context)
        {
            context.WebDriver.Close();
            return CommandExecutionResult.SuccessCommand;
        }
    }
}