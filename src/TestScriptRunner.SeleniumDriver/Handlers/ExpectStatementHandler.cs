using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestScript.Common.Instructions;
using TestScriptRunner.Common.UseDefinitions;
using TestScriptRunner.Driver;

namespace TestScriptRunner.SeleniumDriver.Handlers
{
    public class ExpectStatementHandler : IInstructionHandler
    {
        public ExpectStatementHandler(ExpectStatementInstruction expectStatementInstruction)
        {
            ComparerOperator = expectStatementInstruction.ComparerOperator;
            Target = expectStatementInstruction.Target;
            Value = expectStatementInstruction.Value;
        }

        public ExpectComparerOperator ComparerOperator { get; }
        public string Target { get; }
        public string Value { get; }

        public void Handle(IEnumerable<TestCaseUseDefinition> definitions, BrowserScope scope)
        {
            var definition = definitions.SelectMany(x => x.Definitions).FirstOrDefault(x => x.Key == Target);

            var element = scope.Default.FindByDefinition(definition);
            var isSatisfied = false;

            switch (ComparerOperator)
            {
                case ExpectComparerOperator.Equal:
                    isSatisfied = CompareEquality(element.Text, Value);
                    break;
                case ExpectComparerOperator.NotEqual:
                    isSatisfied = !CompareEquality(element.Text, Value);
                    break;
                case ExpectComparerOperator.Greater:
                    isSatisfied = IsGreaterThan(element.Text, Value);
                    break;
                case ExpectComparerOperator.GreaterThanOrEqual:
                    isSatisfied = IsGreaterThanOrEqual(element.Text, Value);
                    break;
                case ExpectComparerOperator.Smaller:
                    isSatisfied = IsSmallerThan(element.Text, Value);
                    break;
                case ExpectComparerOperator.SmallerThanOrEqual:
                    isSatisfied = IsSmallerThanOrEqual(element.Text, Value);
                    break;
                default:
                    throw new ArgumentException(nameof(ComparerOperator));
            }

            if (!isSatisfied)
                throw new ExpectationNotSatisfiedException($"Expectation failed for '{Target}' {GetMessage(ComparerOperator)} '{Value}'.");
        }

        private object GetMessage(ExpectComparerOperator comparerOperator)
        {
            switch (comparerOperator)
            {
                case ExpectComparerOperator.Equal:
                    return "equal to";
                case ExpectComparerOperator.NotEqual:
                    return "not equal to";
                case ExpectComparerOperator.Greater:
                    return "greater than ";
                case ExpectComparerOperator.GreaterThanOrEqual:
                    return "greater than or equal to";
                case ExpectComparerOperator.Smaller:
                    return "smaller than";
                case ExpectComparerOperator.SmallerThanOrEqual:
                    return "smaller than or equal to";
                default:
                    return string.Empty;
            }
        }

        private bool IsSmallerThanOrEqual(string text, string value)
        {
            if (decimal.TryParse(text, out decimal left) && decimal.TryParse(value, out decimal right))
                return left <= right;

            return string.Compare(text, value) <= 0;
        }

        private bool IsSmallerThan(string text, string value)
        {
            if (decimal.TryParse(text, out decimal left) && decimal.TryParse(value, out decimal right))
                return left < right;

            return string.Compare(text, value) < 0;
        }

        private bool IsGreaterThanOrEqual(string text, string value)
        {
            if (decimal.TryParse(text, out decimal left) && decimal.TryParse(value, out decimal right))
                return left >= right;

            return string.Compare(text, value) >= 0;
        }

        private bool IsGreaterThan(string text, string value)
        {
            if (decimal.TryParse(text, out decimal left) && decimal.TryParse(value, out decimal right))
                return left > right;

            return string.Compare(text, value) > 0;
        }

        private bool CompareEquality(string text, string value)
        {
            if (decimal.TryParse(text, out decimal left) && decimal.TryParse(value, out decimal right))
                return left == right;

            return string.Compare(text, value) == 0;
        }
    }
}
