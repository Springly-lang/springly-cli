namespace SpringlyLang.Common.Instructions
{
    public abstract class InstructionBase
    {
        protected InstructionBase(InstructionSourceLocation location)
        {
            SourceLocation = location;
        }

        public InstructionSourceLocation SourceLocation { get; }
    }
}
