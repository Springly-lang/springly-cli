using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public class CloseBrowserCommand : ICommand
    {
        private readonly string CloseNamedBrowserPattern = $"^(close\\s+{WellKnownPatterns.BrowserName})";
        private const string CloseBrowserPattern = "^(close\\s+browser)";

        public ExecutionResult Execute(string statement, ExecutionContext context)
        {
            if (Regex.IsMatch(statement, CloseBrowserPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline))
            {
                context.Release(ExecutionContext.DefaultBrowserName);
                return ExecutionResult.Success;
            }

            var match = Regex.Match(statement, CloseNamedBrowserPattern, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            if (match.Success)
            {
                var name = match.Groups["name"].Value;
                context.Release(name);

                return ExecutionResult.Success;
            }

            return ExecutionResult.Continue;
        }
    }
}
