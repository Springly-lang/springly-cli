using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using TestScript.Common;
using TestScriptRunner.Common.UseDefinitions;
using TestScriptRunner.Driver;

namespace TestScriptRunner.SeleniumDriver
{
    public class SeleniumTestScriptExecuter : ITestScriptExecuter
    {
        public SeleniumTestScriptExecuter(ILogger<SeleniumTestScriptExecuter> logger, IInstructionHandlerFactory instructionHandlerFactory)
        {
            Logger = logger;
            InstructionHandlerFactory = instructionHandlerFactory;
        }

        public ILogger<SeleniumTestScriptExecuter> Logger { get; }
        public IInstructionHandlerFactory InstructionHandlerFactory { get; }

        public void Execute(IEnumerable<TestScriptContext> contexts)
        {
            var executer = new TestCaseExecuter(InstructionHandlerFactory);
            foreach (var context in contexts)
            {
                Logger.LogInformation($"Running '{context.SourceFile.FileName}'");

                foreach (var testCase in context.TestCases)
                {
                    Logger.LogInformation($"Test Case '{testCase.Name}' started...");
                    executer.Execute(testCase, context.Definitions);
                }
            }
        }
    }
}
