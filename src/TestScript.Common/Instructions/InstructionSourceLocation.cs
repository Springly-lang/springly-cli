namespace TestScript.Common.Instructions
{
    public class InstructionSourceLocation
    {
        public InstructionSourceLocation(int lineNumber, int column, string fileName)
        {
            LineNumber = lineNumber + 1;
            Column = column;
            FileName = fileName;
        }

        public int LineNumber { get; }
        public int Column { get; }
        public string FileName { get; }
    }
}
