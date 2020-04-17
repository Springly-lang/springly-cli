namespace TestScript.Common.Instructions
{
    public class ExpectStatementInstruction : InstructionBase
    {
        public ExpectStatementInstruction(string target, ExpectComparerOperator comparerOperator, string value, InstructionSourceLocation location) : base(location)
        {
            ComparerOperator = comparerOperator;
            Target = target;
            Value = value;
        }

        public ExpectComparerOperator ComparerOperator { get; }

        public string Target { get; }
        
        public string Value { get; }
    }

    public enum ExpectComparerOperator
    {
        Equal,
        NotEqual,
        Greater,
        GreaterThanOrEqual,
        Less,
        LessThanOrEqual,
    }
}
