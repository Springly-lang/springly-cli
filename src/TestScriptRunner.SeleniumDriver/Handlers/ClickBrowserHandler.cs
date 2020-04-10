using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestScript.Common.Instructions;
using TestScriptRunner.Common.UseDefinitions;

namespace TestScriptRunner.SeleniumDriver.Handlers
{
    public class ClickBrowserHandler : IInstructionHandler
    {
        private ClickBrowserInstruction _clickBrowserInstruction;

        public ClickBrowserHandler(ClickBrowserInstruction clickBrowserInstruction)
        {
            _clickBrowserInstruction = clickBrowserInstruction;
        }

        public void Handle(IEnumerable<TestCaseUseDefinition> definitions, BrowserScope scope)
        {
            var target = definitions.SelectMany(x => x.Definitions).SingleOrDefault(x => x.Key == _clickBrowserInstruction.Target);
            if (target == null)
            {
                throw new InvalidOperationException($"Identifier {_clickBrowserInstruction.Target} not found in referenced definitions.");
            }

            var driver = scope.Default;
            var element = driver.FindByDefinition(target);

            for (var i = 0; i < _clickBrowserInstruction.ClickTimes; i++)
            {
                switch (_clickBrowserInstruction.ClickType)
                {
                    case ClickType.SingleClick:
                        new Actions(driver).Click(element).Build().Perform();
                        break;
                    case ClickType.DoubleClick:
                        new Actions(driver).DoubleClick(element).Build().Perform();
                        break;
                    case ClickType.RightClick:
                        new Actions(driver).ContextClick(element).Build().Perform();
                        break;
                }

            }
        }
    }
}
