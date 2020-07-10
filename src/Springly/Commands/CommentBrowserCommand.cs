using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public class CommentBrowserCommand : RegexCommandBase
    {
        public int Order => 0;
        public override string Pattern => "^(#).*";
        protected override ExecutionResult InternalExecute(Match match, ExecutionContext context) => ExecutionResult.Success;
    }
}
