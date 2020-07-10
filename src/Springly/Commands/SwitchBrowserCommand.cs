using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public class SwitchBrowserCommand : RegexCommandBase
    {
        public override string Pattern => "^(switch\\s+to\\s+(?<name>[_\\w*]*\\w+[_\\w*]))";

        protected override ExecutionResult InternalExecute(Match match, ExecutionContext context)
        {
            var name = match.Groups["name"].Value;
            context.SwitchTo(name);

            return ExecutionResult.Success;
        }
    }
}
