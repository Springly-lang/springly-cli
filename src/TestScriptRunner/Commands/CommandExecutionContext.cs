using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SpringlyLang.UseDefinitions;

namespace SpringlyLang.Commands
{
    public class CommandExecutionContext
    {
        public CommandExecutionContext(ILogger logger)
        {
            Logger = logger;
        }

        public TestCaseUseDefinition Definitions { get; set; }

        public TestCaseSourceFile SourceFile { get; set; }

        public string TestCaseTitle { get; set; }

        public ILogger Logger { get; }

        public IWebDriver WebDriver { get; private set; }

        public void SetChromeDriver()
        {
            WebDriver = new ChromeDriver();
        }

        public void SetFirefoxDriver()
        {
            WebDriver = new FirefoxDriver();
        }

        public void SetEdgeDriver()
        {
            WebDriver = new EdgeDriver();
        }
    }
}