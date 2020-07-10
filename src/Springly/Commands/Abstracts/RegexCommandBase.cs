using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public abstract class RegexCommandBase : ICommand
    {
        protected abstract string[] Patterns { get; }

        public ExecutionResult Execute(string statement, ExecutionContext context)
        {
            var index = 0;
            foreach (var pattern in Patterns)
            {
                var match = Regex.Match(statement, pattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                if (match.Success)
                {
                    return InternalExecute(match, index, context);
                }
                index++;
            }

            return ExecutionResult.Continue;
        }

        protected abstract ExecutionResult InternalExecute(Match match, int patternIndex, ExecutionContext context);
    }
}
