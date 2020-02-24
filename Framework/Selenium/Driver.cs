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
        [ThreadStatic] 
        public static IWebDriver _driver;

        [ThreadStatic] 
        public static Wait Wait;

        public static void Init(string browserName)
        {
            _driver = DriverFactory.Build(browserName);
            Wait = new Wait(10);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");
        public static string Title => Current.Title;

        public static void GoTo(string url)
        {
            if (!url.StartsWith("http"))
            {
                url = $"http://{url}";
            }

            FW.Log.Info(url);
            Current.Navigate().GoToUrl(url);
        }

        public static Element FindElement(By by, string elementName)
        {
            return new Element(Current.FindElement(by), elementName)
            {
                FoundBy = by
            };
        }

        public static Elements FindElements(By by)
        {
            return new Elements(Current.FindElements(by))
            {
                FoundBy = by
            };
        }

        public static void Quit()
        {
            FW.Log.Info("Close Browser");
            Current.Quit();
        }

        public static void WindowMaximize()
        {
            Current.Manage().Window.Maximize();
        }
    }
}
