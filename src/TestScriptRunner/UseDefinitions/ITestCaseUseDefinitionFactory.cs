namespace TestScriptRunner.UseDefinitions
{
    public interface ITestCaseUseDefinitionFactory
    {
        TestCaseUseDefinition Create(string definitionContent);
    }
}