﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SpringlyLang.Common.UseDefinitions;
using SpringlyLang.Driver;

namespace SpringlyLang.SeleniumDriver
{
    public class BrowserScope
    {
        private readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();

        public IWebDriver this[string browserName]
        {
            get => Drivers[browserName];
        }

        public void Define(string browserName)
        {
            //var allTargets = EnvironmentVariableTarget.Machine | EnvironmentVariableTarget.User | EnvironmentVariableTarget.Process;
            //var chromeDriverPath = Environment.GetEnvironmentVariable("CHROMEWEBDRIVER", allTargets);
            Drivers.Add(browserName, new ChromeDriver(Directory.GetCurrentDirectory()));
            //if (string.IsNullOrWhiteSpace(chromeDriverPath))
            //{
            //    Drivers.Add(browserName, new ChromeDriver());
            //}
            //else
            //{
            //    Drivers.Add(browserName, new ChromeDriver(chromeDriverPath));
            //}
        }

        public void Release(string browserName)
        {
            this[browserName].Quit();
            this[browserName].Dispose();
            Drivers.Remove(browserName);
        }

        public void DefineDefaultBrowser() => Define(WellKnownDriverNames.DefaultBrowserName);

        public bool Exists(string browserName) => Drivers.ContainsKey(browserName);

        public bool IsEmpty => Drivers.Count == 0;

        public IWebDriver Default => this[WellKnownDriverNames.DefaultBrowserName] ?? Drivers.Values.FirstOrDefault();
    }

    public static class IWebDriverExtensions
    {
        public static IWebElement FindByDefinition(this IWebDriver driver, TestCaseDefinition definition)
        {
            if (definition.Type == DefinitionType.CssSelector)
            {
                return driver.FindElement(By.CssSelector(definition.CssSelector));
            }
            else
            {
                return driver.FindElement(By.XPath(definition.XPath));
            }
        }

        public static IEnumerable<IWebElement> FindManyByDefinition(this IWebDriver driver, TestCaseDefinition definition)
        {
            if (definition.Type == DefinitionType.CssSelector)
            {
                return driver.FindElements(By.CssSelector(definition.CssSelector));
            }
            else
            {
                return driver.FindElements(By.XPath(definition.XPath));
            }
        }
    }
}