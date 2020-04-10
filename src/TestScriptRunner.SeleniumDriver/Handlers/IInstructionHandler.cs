using OpenQA.Selenium;
using System.Collections.Generic;
using TestScriptRunner.Common.UseDefinitions;

namespace TestScriptRunner.SeleniumDriver
{
    public interface IInstructionHandler
    {
        void Handle(IEnumerable<TestCaseUseDefinition> definitions, BrowserScope scope);
    }
}
