namespace TestScript.Common.Instructions
{

    public class BrowserNavigateInstruction : BrowserInstructionBase
    {
        public BrowserNavigateInstruction(string url)
        {
            Url = url;
        }

        public string Url { get; }
    }
}
