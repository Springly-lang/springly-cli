using TestScriptRunner.UseDefinitions;

namespace TestScriptRunner.Commands
{
    public class CommandExecutionContext
    {
        public CommandExecutionContext(ILogger logger)
        {
            Logger = logger;
        }

        public TestCaseUseDefinition Definitions { get; set; }

        public TestCaseSourceFile SourceFile { get; set; }

        public string TestCaseTitle { get; set; }
        public ILogger Logger { get; }
    }
}