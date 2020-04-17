using SpringlyLang.UseDefinitions;

namespace SpringlyLang.Commands
{
    public interface ICommandFactory
    {
        ITestCaseUseDefinitionFactory TestCaseUseDefinitionFactory { get; }

        CommandBase Create(Statement statement);
    }
}