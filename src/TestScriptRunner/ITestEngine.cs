namespace TestScriptRunner
{
    public interface ITestEngine
    {
        ExecutionResult Execute(TestCaseSourceFile[] files);
    }
}