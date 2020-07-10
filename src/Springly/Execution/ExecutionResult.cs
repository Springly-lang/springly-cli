namespace Springly
{
    public class ExecutionResult
    {
        public static readonly ExecutionResult Success = new ExecutionResult(false, null);

        public static readonly ExecutionResult Continue = new ExecutionResult(true, "Continue to the next command.");

        private ExecutionResult(bool @continue, string error)
        {
            ShouldContinue = @continue;
            ErrorMessage = error;
        }

        public bool ShouldContinue { get; }

        public bool IsSuccess => string.IsNullOrEmpty(ErrorMessage);

        public string ErrorMessage { get; set; }
    }
}
