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
            AcceptCookies();
            Driver.Wait.Until(drvr => Map.OtherStoresButton.Displayed);
            return this;
        }

        public void AcceptCookies()
        {
            Map.AcceptCookiesButton.Click();
            Driver.Wait.Until(drvr => !Map.AcceptCookiesButton.Displayed);
        }

        public void OpenAppStore()
        {
            Map.AppStore.Click();
        }

        public void OpenGooglePlay()
        {
            Map.GooglePlay.Click();
        }
    }

    public class CopyDeckPageMap
    {
        public IWebElement YesButton => Driver.FindElement(By.Id("button-open"));
        public IWebElement NoButton => Driver.FindElement(By.Id("not-installed"));
        public IWebElement AppStore => Driver.FindElement(By.XPath("//a[text()='App Store']"));
        public IWebElement GooglePlay => Driver.FindElement(By.XPath("//a[text()='Google Play']"));
        public IWebElement AcceptCookiesButton => Driver.FindElement(By.CssSelector("a.cc-btn.cc-dismiss"));
        public IWebElement OtherStoresButton => Driver.FindElement(By.Id("other-stores"));
        public IWebElement CopiedMessage => Driver.FindElement(By.CssSelector(".notes.active"));
    }
}
