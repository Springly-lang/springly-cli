namespace TestScriptRunner
{
    public interface ITestEngine
    {
        void Execute(TestCaseSourceFile[] files);
    }
}