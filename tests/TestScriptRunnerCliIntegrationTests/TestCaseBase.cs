using Microsoft.Extensions.Logging;
using Moq;
using TestScript.Common;
using TestScriptRunner.Cli;
using TestScriptRunner.Common.UseDefinitions;
using TestScriptRunner.Language;
using TestScriptRunner.SeleniumDriver;

namespace TestScriptRunnerCliIntegrationTests
{
    public abstract class TestCaseBase
    {
        protected Program CreateProgramInstance()
        {
            var reader = new SourceFileReader();
            var logger = new Mock<ILogger<SeleniumTestScriptExecuter>>().Object;
            var interpreter = new IronyTestScriptInterpreter(new UseDefinitionFactory());
            var executer = new SeleniumTestScriptExecuter(logger, new InstructionHandlerFactory());

            return new Program(reader, interpreter, executer);
        }
    }
}
