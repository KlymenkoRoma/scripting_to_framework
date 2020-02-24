using Framework;
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
            FW.Log.Step("Click 'Accept cookies' button");
            Map.AcceptCookiesButton.Click();
            Driver.Wait.Until(drvr => !Map.AcceptCookiesButton.Displayed);
        }

        public void OpenAppStore()
        {
            FW.Log.Step("Click AppStore link");
            Map.AppStore.Click();
        }

        public void OpenGooglePlay()
        {
            FW.Log.Step("Click GooglePlay link");
            Map.GooglePlay.Click();
        }
    }

    public class CopyDeckPageMap
    {
        public Element YesButton => Driver.FindElement(By.Id("button-open"), "Yes button");
        public Element NoButton => Driver.FindElement(By.Id("not-installed"), "No button");
        public Element AppStore => Driver.FindElement(By.XPath("//a[text()='App Store']"), "AppStore button");
        public Element GooglePlay => Driver.FindElement(By.XPath("//a[text()='Google Play']"), "GooglePlay button");
        public Element AcceptCookiesButton => Driver.FindElement(By.CssSelector("a.cc-btn.cc-dismiss"), "Accept Cookies button");
        public Element OtherStoresButton => Driver.FindElement(By.Id("other-stores"), "Other Stores button");
        public Element CopiedMessage => Driver.FindElement(By.CssSelector(".notes.active"), "Copied message");
    }
}
