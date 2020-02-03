namespace TestScriptRunner
{
    public class TestCaseSourceFile
    {
        public TestCaseSourceFile(string fileName, string content)
        {
            FileName = fileName;
            Content = content;
        }

        public string FileName { get; }

        public string Content { get; }
    }
}
