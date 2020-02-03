using TestScriptRunner.UseDefinitions;

namespace TestScriptRunner.Commands
{
    public class CommandExecutionContext
    {
        public CommandExecutionContext()
        {

        }

        public TestCaseUseDefinition Definitions { get; set; }

        public TestCaseSourceFile SourceFile { get; set; }

        public string TestCaseTitle { get; set; }
    }
}