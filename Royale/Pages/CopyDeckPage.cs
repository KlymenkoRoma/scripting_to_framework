using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Royale.Pages
{
    public class CopyDeckPage
    {
        public readonly CopyDeckPageMap Map;

        public CopyDeckPage()
        {
            Map = new CopyDeckPageMap();
        }

        public CopyDeckPage Yes()
        {
            Map.YesButton.Click();
            Driver.Wait.Until(drvr => Map.CopiedMessage.Displayed);
            return this;
        }

        public CopyDeckPage No()
        {
            Map.NoButton.Click();
            return this;
        }

        public void OpenAppStore()
        {

        }

        public void OpenGooglePlay()
        {

        }
    }

    public class CopyDeckPageMap
    {
        public IWebElement YesButton => Driver.FindElement(By.Id("button-open"));
        public IWebElement NoButton => Driver.FindElement(By.Id("not-installed"));
        public IWebElement CopiedMessage => Driver.FindElement(By.CssSelector(".notes.active"));
    }
}
