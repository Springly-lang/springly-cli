using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public class CommentBrowserCommand : RegexCommandBase
    {
        public int Order => 0;
        protected override string[] Patterns => new[] { "^(#).*" };
        protected override ExecutionResult InternalExecute(Match match, int patternIndex, ExecutionContext context) => ExecutionResult.Success;
    }
}
