namespace TestScript.Common.Instructions
{
    public class CloseBrowserInstruction : BrowserInstructionBase
    {
        public CloseBrowserInstruction(string browserName, InstructionSourceLocation location) : base(location)
        {
            BrowserName = browserName;
        }

        public string BrowserName { get; }
    }
}
