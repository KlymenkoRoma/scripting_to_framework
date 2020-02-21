using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic] public static IWebDriver _driver;

        [ThreadStatic] public static Wait Wait;

        public static void Init()
        {
            _driver = new ChromeDriver();
            Wait = new Wait(10);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");

        public static void GoTo(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }

            Current.Navigate().GoToUrl(url);
        }

        public static IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        public static IList<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }

        public static void Quit()
        {
            Current.Quit();
        }

        public static void WindowMaximize()
        {
            Current.Manage().Window.Maximize();
        }
    }
}
