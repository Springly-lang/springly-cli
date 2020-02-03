namespace TestScriptRunner.Commands
{
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