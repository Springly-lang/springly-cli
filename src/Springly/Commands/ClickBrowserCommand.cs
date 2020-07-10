using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public class ClickBrowserCommand : RegexCommandBase
    {
        protected override string[] Patterns => new[]
        {
            // By element id
            $"^click\\s+on\\s+{WellKnownPatterns.Id}",
            $"^double\\s+click\\s+on\\s+{WellKnownPatterns.Id}",
            $"^right\\s+click\\s+on\\s+{WellKnownPatterns.Id}",

            // By CSS selector
            $"^click\\s+on\\s+{WellKnownPatterns.CssSelector}",
            $"^double\\s+click\\s+on\\s+{WellKnownPatterns.CssSelector}",
            $"^right\\s+click\\s+on\\s+{WellKnownPatterns.CssSelector}",

            // By position
            $"^click\\s+on\\s+\\(\\s*{WellKnownPatterns.Coordinate}",
            $"^double\\s+click\\s+on\\s+\\(\\s*{WellKnownPatterns.Coordinate}",
            $"^right\\s+click\\s+on\\s+\\(\\s*{WellKnownPatterns.Coordinate}",
        };

        protected override ExecutionResult InternalExecute(Match match, int patternIndex, ExecutionContext context)
        {
            switch (patternIndex)
            {
                // By Id
                case 0:
                    var e0 = context.Current.FindElement(By.Id(match.Groups["id"].Value));
                    new Actions(context.Current).Click(e0);
                    break;

                case 1:
                    var e1 = context.Current.FindElement(By.Id(match.Groups["id"].Value));
                    new Actions(context.Current).DoubleClick(e1);
                    break;

                case 2:
                    var e2 = context.Current.FindElement(By.Id(match.Groups["id"].Value));
                    new Actions(context.Current).ContextClick(e2);
                    break;

                // By CSS selector
                case 3:
                    var e3 = context.Current.FindElement(By.CssSelector(match.Groups["selector"].Value));
                    new Actions(context.Current).Click(e3);
                    break;

                case 4:
                    var e4 = context.Current.FindElement(By.CssSelector(match.Groups["selector"].Value));
                    new Actions(context.Current).DoubleClick(e4);
                    break;

                case 5:
                    var e5 = context.Current.FindElement(By.CssSelector(match.Groups["selector"].Value));
                    new Actions(context.Current).ContextClick(e5);
                    break;

                // By position
                case 6:
                    var (x6, y6) = (int.Parse(match.Groups["x"].Value), int.Parse(match.Groups["y"].Value));
                    new Actions(context.Current).MoveByOffset(x6, y6).Click();
                    break;

                case 7:
                    var (x7, y7) = (int.Parse(match.Groups["x"].Value), int.Parse(match.Groups["y"].Value));
                    new Actions(context.Current).MoveByOffset(x7, y7).DoubleClick();
                    break;

                case 8:
                    var (x8, y8) = (int.Parse(match.Groups["x"].Value), int.Parse(match.Groups["y"].Value));
                    new Actions(context.Current).MoveByOffset(x8, y8).ContextClick();
                    break;


                default:
                    throw new ArgumentException("Pattern index not found!", nameof(patternIndex));
            }

            return ExecutionResult.Success;
        }
    }
}
