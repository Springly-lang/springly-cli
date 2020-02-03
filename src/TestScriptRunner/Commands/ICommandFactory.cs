using TestScriptRunner.UseDefinitions;

namespace TestScriptRunner.Commands
{
    public interface ICommandFactory
    {
        ITestCaseUseDefinitionFactory TestCaseUseDefinitionFactory { get; }

        CommandBase Create(Statement statement);
    }
}