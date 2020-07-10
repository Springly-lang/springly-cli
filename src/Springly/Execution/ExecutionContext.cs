using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Linq;

namespace Springly
{
    public class ExecutionContext
    {
        public const string DefaultBrowserName = "default";

        public IWebDriver Current => _browsers[_browserNames.Peek()];

        private Stack<string> _browserNames = new Stack<string>();
        private Dictionary<string, IWebDriver> _browsers { get; set; } = new Dictionary<string, IWebDriver>();

        public string Name { get; set; }

        public void SwitchTo(string name, bool isNew = false, string browser = null)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new System.ArgumentNullException(nameof(name));
            }

            if (!isNew && !_browsers.ContainsKey(name))
            {
                throw new BrowserCommandException($"There is no browser named '{name}' in this context.");
            }

            if (isNew && _browsers.ContainsKey(name))
            {
                throw new BrowserCommandException($"A browser named '{name}' already exists in this context.");
            }

            if (isNew)
            {
                _browsers.Add(name, GetDriver(browser));
            }

            _browserNames.Push(name);
        }

        public void Release(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new System.ArgumentNullException(nameof(name));
            }

            if (!_browsers.ContainsKey(name))
            {
                throw new BrowserCommandException($"There is no browser named '{name}' in this context.");
            }

            _browsers[name].Close();
            _browsers[name].Quit();
            _browsers[name].Dispose();
            _browsers.Remove(name);

            if (_browserNames.Any())
            {
                _browserNames.Pop();
            }
        }

        private static IWebDriver GetDriver(string browser)
        {
            switch (browser)
            {
                case "chrome":
                default:
                    return new ChromeDriver();
            }
        }
    }
}
