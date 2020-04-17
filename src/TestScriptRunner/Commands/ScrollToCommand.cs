namespace SpringlyLang.Commands
{
    public class ScrollToCommand : CommandBase
    {
        public ScrollToCommand(Statement statement) : base(statement)
        {
        }

        public override CommandExecutionResult Execute(CommandExecutionContext context)
        {
            return CommandExecutionResult.SuccessCommand;
        }
    }
}