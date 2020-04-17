using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpringlyLang.Common.Instructions;
using SpringlyLang.Common.UseDefinitions;
using SpringlyLang.Driver;

namespace SpringlyLang.SeleniumDriver.Handlers
{
    public class ExpectStatementHandler : IInstructionHandler
    {
        public ExpectStatementHandler(ExpectStatementInstruction expectStatementInstruction)
        {
            ComparerOperator = expectStatementInstruction.ComparerOperator;
            Target = expectStatementInstruction.Target;
            Value = expectStatementInstruction.Value;
            SourceLocation = expectStatementInstruction.SourceLocation;
        }

        public ExpectComparerOperator ComparerOperator { get; }
        public string Target { get; }
        public string Value { get; }
        public InstructionSourceLocation SourceLocation { get; }

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
                case ExpectComparerOperator.Less:
                    isSatisfied = IsSmallerThan(element.Text, Value);
                    break;
                case ExpectComparerOperator.LessThanOrEqual:
                    isSatisfied = IsSmallerThanOrEqual(element.Text, Value);
                    break;
                default:
                    throw new ArgumentException(nameof(ComparerOperator));
            }

            if (!isSatisfied)
            {
                var message = $"Expectation failed for '{Target}' {GetMessage(ComparerOperator)} '{Value}' at {SourceLocation.FileName}:{SourceLocation.LineNumber}.";
                throw new ExpectationNotSatisfiedException(message, SourceLocation.LineNumber, SourceLocation.Column, SourceLocation.FileName);
            }
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
                case ExpectComparerOperator.Less:
                    return "smaller than";
                case ExpectComparerOperator.LessThanOrEqual:
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
