using OpenQA.Selenium;
using System;
using System.Text.RegularExpressions;

namespace Springly.Commands
{
    public class ExpectBrowserCommand : RegexCommandBase
    {
        protected override string[] Patterns => new[]
        {
            $"^expect\\s+{WellKnownPatterns.Id}\\s+{WellKnownPatterns.CompareOp}\\s+(?<value>.*)",
            $"^expect\\s+{WellKnownPatterns.CssSelector}\\s+{WellKnownPatterns.CompareOp}\\s+(?<value>.*)"
        };

        protected override ExecutionResult InternalExecute(Match match, int patternIndex, ExecutionContext context)
        {
            var element = patternIndex == 0 ?
                context.Current.FindElement(By.Id(match.Groups["id"].Value)) :
                context.Current.FindElement(By.CssSelector(match.Groups["selector"].Value));
            var actualValue = element.TagName == "input" ? element.GetAttribute("value") : element.Text;

            var op = match.Groups["op"].Value;
            var expectedValue = match.Groups["value"].Value;
            var fixedOp = string.Join(' ', op.Split(' ', StringSplitOptions.RemoveEmptyEntries));

            Assert(expectedValue, fixedOp, actualValue);

            return ExecutionResult.Success;
        }

        private bool Assert(string expectedValue, string op, string actualValue)
        {
            switch (op)
            {
                case "not equal":
                    return expectedValue != actualValue;

                case "equal":
                    return expectedValue == actualValue;

                case "not contain":
                    return !actualValue.Contains(expectedValue);

                case "contain":
                    return actualValue.Contains(expectedValue);

                case "greater than":
                    //return Numeric(actualValue) > Numeric(expectedValue);
                    return actualValue.CompareTo(expectedValue) > 0;

                case "greater than or equal":
                    //return Numeric(actualValue) >= Numeric(expectedValue);
                    return actualValue.CompareTo(expectedValue) >= 0;

                case "smaller than":
                    //return Numeric(actualValue) < Numeric(expectedValue);
                    return actualValue.CompareTo(expectedValue) < 0;

                case "smaller than or equal":
                    //return Numeric(actualValue) <= Numeric(expectedValue);
                    return actualValue.CompareTo(expectedValue) <= 0;

                default:
                    throw new ArgumentException($"Assert operation '{op}' is not supported.");
            }
        }

        private double Numeric(string value)
        {
            return double.TryParse(value, out double x) ? x : double.NaN;
        }
    }
}
