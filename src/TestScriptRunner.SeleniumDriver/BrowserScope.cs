using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;
using TestScriptRunner.Driver;

namespace TestScriptRunner.SeleniumDriver
{
    public class BrowserScope
    {
        private readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();

        public IWebDriver this[string browserName]
        {
            get => Drivers[browserName];
        }

        public void Define(string browserName) => Drivers.Add(browserName, new ChromeDriver());

        public void DefineDefaultBrowser() => Define(WellKnownDriverNames.DefaultBrowserName);

        public bool Exists(string browserName) => Drivers.ContainsKey(browserName);

        public bool IsEmpty => Drivers.Count == 0;

        public IWebDriver Default => this[WellKnownDriverNames.DefaultBrowserName] ?? Drivers.Values.FirstOrDefault();
    }
}
