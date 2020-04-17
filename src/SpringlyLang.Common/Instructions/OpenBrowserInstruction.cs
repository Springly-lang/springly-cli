namespace SpringlyLang.Common.Instructions
{
    public class OpenBrowserInstruction : BrowserInstructionBase
    {
        public OpenBrowserInstruction(string browserName, InstructionSourceLocation location) : base(location)
        {
            BrowserName = browserName;
        }

        public string BrowserName { get; }
    }
}
