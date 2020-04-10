using OpenQA.Selenium;
using System.Collections.Generic;
using TestScript.Common;
using TestScriptRunner.Common.UseDefinitions;

namespace TestScriptRunner.SeleniumDriver
{
    public class TestCaseExecuter
    {
        private readonly BrowserScope _scope = new BrowserScope();

        public TestCaseExecuter(IInstructionHandlerFactory instructionHandlerFactory)
        {
            InstructionHandlerFactory = instructionHandlerFactory;
        }

        public IInstructionHandlerFactory InstructionHandlerFactory { get; }

        public void Execute(TestCase testCase, IEnumerable<TestCaseUseDefinition> definitions)
        {
            foreach (var instruction in testCase.Instructions)
            {
                var handler = InstructionHandlerFactory.Create(instruction);
                handler.Handle(definitions, _scope);
            }
        }
    }
}
