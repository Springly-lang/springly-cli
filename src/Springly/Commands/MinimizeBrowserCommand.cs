using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public class MinimizeBrowserCommand : RegexCommandBase
    {
        protected override string[] Patterns => new[] { "^(minimize\\s+browser)" };

        protected override ExecutionResult InternalExecute(Match match, int patternIndex, ExecutionContext context)
        {
            context.Current.Manage().Window.Minimize();
            return ExecutionResult.Success;
        }
    }
}
