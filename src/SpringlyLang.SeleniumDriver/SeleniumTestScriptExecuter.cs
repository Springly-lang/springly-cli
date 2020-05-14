using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using SpringlyLang.Common;
using SpringlyLang.Common.UseDefinitions;
using SpringlyLang.Driver;

namespace SpringlyLang.SeleniumDriver
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
                    Logger.LogInformation($"Test Case {testCase.Name} started...");
                    executer.Execute(testCase, context.Definitions);
                }
            }
        }
    }
}
