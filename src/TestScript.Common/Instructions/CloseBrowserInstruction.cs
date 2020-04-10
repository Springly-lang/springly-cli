namespace TestScript.Common.Instructions
{

    public class CloseBrowserInstruction : BrowserInstructionBase
    {
        public CloseBrowserInstruction(string browserName)
        {
            BrowserName = browserName;
        }

        public string BrowserName { get; }
    }
}
