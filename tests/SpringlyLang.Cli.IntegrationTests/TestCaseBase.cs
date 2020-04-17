using Microsoft.Extensions.Logging;
using Moq;
using System.IO;
using System.Linq;
using SpringlyLang.Common;
using SpringlyLang.Cli;
using SpringlyLang.Common.UseDefinitions;
using SpringlyLang.Language;
using SpringlyLang.SeleniumDriver;

namespace SpringlyLangCliIntegrationTests
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

        protected string[] SetupFiles(string assetsFolderName, params string[] scriptFileNames)
        {
            var baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), assetsFolderName);
            var args = scriptFileNames.Select(scriptFileName => Path.Combine(baseDirectory, scriptFileName)).ToArray();

            var indexFileName = Path.Combine(baseDirectory, "index.html");
            indexFileName = "file:///" + indexFileName.Replace(@"\", "/");
            foreach (var file in args)
            {
                var content = File.ReadAllText(file);
                content = content.Replace("$INDEX_FILE_PATH$", indexFileName);
                File.WriteAllText(file, content);
            }

            return args;
        }
    }
}
