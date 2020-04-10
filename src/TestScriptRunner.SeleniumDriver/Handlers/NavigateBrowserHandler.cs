using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TestScript.Common.Instructions;
using TestScriptRunner.Common.UseDefinitions;
using TestScriptRunner.Driver;

namespace TestScriptRunner.SeleniumDriver.Handlers
{
    public class NavigateBrowserHandler : IInstructionHandler
    {
        private readonly BrowserNavigateInstruction _browserNavigateInstruction;

        public NavigateBrowserHandler(BrowserNavigateInstruction browserNavigateInstruction)
        {
            _browserNavigateInstruction = browserNavigateInstruction;
        }
        public void Handle(IEnumerable<TestCaseUseDefinition> definitions, BrowserScope scope)
        {
            // Named browser is not supported yet.

            if (scope.IsEmpty)
                throw new SyntaxErrorException($"There is no browser in this scope to navigate.");

            scope.Default.Url = _browserNavigateInstruction.Url;
        }
    }
}
