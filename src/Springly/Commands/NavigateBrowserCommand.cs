using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public class NavigateBrowserCommand : RegexCommandBase
    {
        protected override string[] Patterns => new[] {
            @"^(navigate)\s+to\s+(?<url>\w+:\/\/[\w@][\w.:@]+\/?[\w\.?=%&=\-+@/$,]*)",
            @"^(navigate)\s+to\s+(?<url>\w+:\/\/\/[\w@][\w.:@]+\/?[\w\.?=%&=\-+/$,]*)"
        };

        protected override ExecutionResult InternalExecute(Match match, int patternIndex, ExecutionContext context)
        {
            var url = match.Groups["url"].Value;
            context.Current.Navigate().GoToUrl(url);
            return ExecutionResult.Success;
        }
    }
}
