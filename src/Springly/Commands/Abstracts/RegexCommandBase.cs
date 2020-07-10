using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public abstract class RegexCommandBase : ICommand
    {
        public abstract string Pattern { get; }

        public ExecutionResult Execute(string statement, ExecutionContext context)
        {
            var match = Regex.Match(statement, Pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (match.Success)
            {
                return InternalExecute(match, context);
            }

            return ExecutionResult.Continue;
        }

        protected abstract ExecutionResult InternalExecute(Match match, ExecutionContext context);
    }
}
