using System;
using System.IO;
using System.Linq;
using TestScriptRunner.Commands;
using TestScriptRunner.UseDefinitions;

namespace TestScriptRunner
{
    class Program
    {
        const int FileNotFoundErrorCode = 0x2;
        const int InvalidDataErrorCode = 0xC;

        public ITestEngine Engine { get; }

        public Program(ITestEngine engine)
        {
            Engine = engine;
        }

        public void Run(TestCaseSourceFile[] sourceFiles)
        {
            Engine.Execute(sourceFiles);
        }

        static void Main(string[] args)
        {
            var logger = new ConsoleLogger();

            logger.Info("Welcome to Springly test script runner v1.0");
            if (args?.Length == 0)
            {
                logger.Error("No script file is specified.");
                Environment.Exit(InvalidDataErrorCode);
            }

            var missingFileNames = args.Where(tsf => !File.Exists(tsf)).ToArray();
            if (missingFileNames.Any())
            {
                foreach (var missing in missingFileNames)
                {
                    logger.Error($"Test script file not found in path '{missing}'.");
                }

                Environment.Exit(FileNotFoundErrorCode);
            }

            var testCaseFiles = args.Select(arg => new TestCaseSourceFile(arg, File.ReadAllText(arg))).ToArray();

            try
            {
                logger.Info("Test script execution started...");
                var lexer = new Lexer();
                var parser = new Parser();
                var evaluator = new Evaluator(logger);
                var commandFactory = new CommandFactory(new TestCaseUseDefinitionFactory());

                new Program(new TestEngine(lexer, parser, evaluator, commandFactory)).Run(testCaseFiles);
            }
            catch (SyntaxErrorException se)
            {
                logger.Error(se.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

    }
}
