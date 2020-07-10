using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public class NavigateBrowserCommand : RegexCommandBase
    {
        public override string Pattern => @"^(navigate)\s+to\s+(?<url>\w+:\/\/[\w@][\w.:@]+\/?[\w\.?=%&=\-+@/$,]*)";

        protected override ExecutionResult InternalExecute(Match match, ExecutionContext context)
        {
            var url = match.Groups["url"].Value;
            context.Current.Navigate().GoToUrl(url);
            return ExecutionResult.Success;
        }
    }
}
