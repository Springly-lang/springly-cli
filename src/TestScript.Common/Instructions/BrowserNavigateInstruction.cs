namespace SpringlyLang.Common.Instructions
{
    public class BrowserNavigateInstruction : BrowserInstructionBase
    {
        public BrowserNavigateInstruction(string url, InstructionSourceLocation location) : base(location)
        {
            Url = url;
        }

        public string Url { get; }
    }
}
