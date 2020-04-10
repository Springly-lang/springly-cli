namespace TestScript.Common.Instructions
{
    public class OpenBrowserInstruction : BrowserInstructionBase
    {
        public OpenBrowserInstruction(string browserName)
        {
            BrowserName = browserName;
        }

        public string BrowserName { get; }
    }
}
