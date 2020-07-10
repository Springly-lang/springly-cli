using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public class MaximizeBrowserCommand : RegexCommandBase
    {
        protected override string[] Patterns => new[] { "^(maximize\\s+browser)" };

        protected override ExecutionResult InternalExecute(Match match, int patternIndex, ExecutionContext context)
        {
            context.Current.Manage().Window.Maximize();
            return ExecutionResult.Success;
        }
    }
}
