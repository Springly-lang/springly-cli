using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public class TestCaseCommand : RegexCommandBase
    {
        protected override string[] Patterns => new[] { @"^(test\s+case\s+(?<name>\w+(\s+\w+)*))$" };

        protected override ExecutionResult InternalExecute(Match match, int patternIndex, ExecutionContext context)
        {
            context.Name = match.Groups["name"].Value;
            return ExecutionResult.Success;
        }
    }
}
