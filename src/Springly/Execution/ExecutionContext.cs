using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Springly
{
    public class ExecutionContext : IDisposable
    {
        public const string DefaultBrowserName = "default";

        public IWebDriver Current
        {
            get
            {
                if (!_browserNames.IsEmpty)
                {
                    return _browsers[_browserNames.Peek()];
                }

                throw new BrowserCommandException("There is no browser in this context.");
            }
        }

        private HistoryStack _browserNames = new HistoryStack();
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
            _browserNames.Remove(name);
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

        public void Dispose()
        {
            _browserNames.Clear();
            foreach (var driver in _browsers)
            {
                driver.Value.Dispose();
            }
        }

        private class HistoryStack
        {
            private readonly List<string> _history = new List<string>();
            private int _index = -1;

            public bool IsEmpty => _history.Count == 0;

            public void Push(string name)
            {
                _history.Add(name);
                _index++;
            }

            public string Pop()
            {
                var name = _history[_index];
                _index--;
                return name;
            }

            public string Peek() => _history[_index];

            public void Remove(string name)
            {
                if (!IsEmpty)
                {
                    _history.Remove(name);
                    _index = _history.Count - 1;
                }
            }

            public void Clear()
            {
                _history.Clear();
                _index = -1;
            }
        }
    }
}
