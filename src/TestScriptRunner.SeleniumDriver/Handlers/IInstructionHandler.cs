using OpenQA.Selenium;
using System.Collections.Generic;
using SpringlyLang.Common.UseDefinitions;

namespace SpringlyLang.SeleniumDriver
{
    public interface IInstructionHandler
    {
        void Handle(IEnumerable<TestCaseUseDefinition> definitions, BrowserScope scope);
    }
}
