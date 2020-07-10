using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public class OpenBrowserCommand : ICommand
    {
        private const string OpenNamedBrowserPattern = "^(open\\s+(?<browser>(\\w+))\\s+browser\\s+as\\s+(?<name>\\[_\\w*]*w+[_\\w*]))";
        private const string OpenBrowserPattern = "^(open\\s+browser)";

        public bool CanExecute(string statement)
        {
            return Regex.IsMatch(statement, OpenBrowserPattern) || Regex.IsMatch(statement, OpenNamedBrowserPattern);
        }

        public ExecutionResult Execute(string statement, ExecutionContext context)
        {
            var basicMatch = Regex.Match(statement, OpenBrowserPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (basicMatch.Success)
            {
                context.SwitchTo(ExecutionContext.DefaultBrowserName, true);
                return ExecutionResult.Success;
            }

            var namedMatch = Regex.Match(statement, OpenNamedBrowserPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (namedMatch.Success)
            {
                var browser = namedMatch.Groups["browser"].Value;
                var name = namedMatch.Groups["name"].Value;

                context.SwitchTo(name, true, browser);

                return ExecutionResult.Success;
            }

            return ExecutionResult.Continue;
        }
    }
}
