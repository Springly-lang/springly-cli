﻿using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public class SwitchBrowserCommand : RegexCommandBase
    {
        protected override string[] Patterns => new[] { $"^(switch\\s+to\\s+{WellKnownPatterns.BrowserName})" };

        protected override ExecutionResult InternalExecute(Match match, int patternIndex, ExecutionContext context)
        {
            var name = match.Groups["name"].Value;
            context.SwitchTo(name);

            return ExecutionResult.Success;
        }
    }
}
