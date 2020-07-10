using System;
using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public class NavigateBrowserCommand : RegexCommandBase
    {
        protected override string[] Patterns => new[] {
            @"^(navigate)\s+to\s+(?<url>.+)"
        };

        protected override ExecutionResult InternalExecute(Match match, int patternIndex, ExecutionContext context)
        {
            var url = match.Groups["url"].Value;
            if (!Uri.TryCreate(url, UriKind.Absolute, out _))
            {
                throw new SyntaxErrorException($"Url '{url}' is not valid.");
            }

            context.Current.Navigate().GoToUrl(url);
            return ExecutionResult.Success;
        }
    }
}
