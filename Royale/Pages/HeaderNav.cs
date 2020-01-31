using System;
using Framework.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

namespace Royale.Pages
{
    public class HeaderNav
    {
        public readonly HeaderNavMap Map;

        public HeaderNav()
        {
            Map = new HeaderNavMap();
        }

        public void GoToCardsPage()
        {
            Map.CardsTabLink().Click();
        }
    }

    public class HeaderNavMap
    {
        public IWebElement CardsTabLink() { return Driver.FindElement(By.CssSelector("a[href='/cards']")); }
    }
}
