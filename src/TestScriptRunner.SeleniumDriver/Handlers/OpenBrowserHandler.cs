using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Data;
using TestScript.Common.Instructions;
using TestScriptRunner.Common.UseDefinitions;
using TestScriptRunner.Driver;

namespace TestScriptRunner.SeleniumDriver.Handlers
{
    public class OpenBrowserHandler : IInstructionHandler
    {
        private OpenBrowserInstruction _openBrowserInstruction;

        public OpenBrowserHandler(OpenBrowserInstruction openBrowserInstruction)
        {
            _openBrowserInstruction = openBrowserInstruction;
        }

        public void Handle(IEnumerable<TestCaseUseDefinition> definitions, BrowserScope scope)
        {
            // Named browser is not supported yet.
            //if (!string.IsNullOrWhiteSpace(_openBrowserInstruction.BrowserName))
            //{
            //    if (scope.Exists(_openBrowserInstruction.BrowserName))
            //        throw new SyntaxErrorException($"There is an already browser named '{_openBrowserInstruction.BrowserName}' in this scope.");

            //    scope.Define(_openBrowserInstruction.BrowserName);
            //}
            //else
            //{
            //}

            if (scope.Exists(WellKnownDriverNames.DefaultBrowserName))
                throw new SyntaxErrorException($"There is an already open default browser in this scope.");

            scope.DefineDefaultBrowser();
        }
    }
}
