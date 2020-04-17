namespace TestScript.Common.Instructions
{
    public class ClickBrowserInstruction : InstructionBase
    {
        public ClickBrowserInstruction(ClickType clickType, string targetIdentifier, int times, InstructionSourceLocation location) : base(location)
        {
            ClickType = clickType;
            ClickTimes = times;
            Target = targetIdentifier;
        }

        public ClickType ClickType { get; }
        public int ClickTimes { get; }
        public string Target { get; }
    }

    public enum ClickType
    {
        SingleClick = 1,
        DoubleClick = 2,
        RightClick = 3
    }
}
