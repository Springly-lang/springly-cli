using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public class TestCaseCommand : RegexCommandBase
    {
        public override string Pattern => @"^(test\s+case\s+(?<name>\w+(\s+\w+)*))$";

        protected override ExecutionResult InternalExecute(Match match, ExecutionContext context)
        {
            context.Name = match.Groups["name"].Value;
            return ExecutionResult.Success;
        }
    }
}
