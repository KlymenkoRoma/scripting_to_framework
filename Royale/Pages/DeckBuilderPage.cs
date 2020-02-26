using Framework;
using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Royale.Pages
{
    public class DeckBuilderPage : PageBase
    {
        public readonly DeckBuilderPageMap Map;

        public DeckBuilderPage()
        {
            Map = new DeckBuilderPageMap();
        }

        public DeckBuilderPage GoTo()
        {
            HeaderNav.Map.DeckBuilderLink.Click();
            return this;
        }

        public void AddCardsManually()
        {
            //Driver.Wait.Until(drvr => Map.AddCardsManuallyLink.Displayed);
            Driver.Wait.Until(WaitConditions.ElementIsDisplayed(Map.AddCardsManuallyLink)).Click();
            //Map.AddCardsManuallyLink.Click();
            //Driver.Wait.Until(drvr => Map.CopyDeckIcon.Displayed);
            Driver.Wait.Until(WaitConditions.ElementDisplayed(Map.CopyDeckIcon));
        }

        public void CopySuggestedDeck()
        {
            Map.CopyDeckIcon.Click();
        }
    }

    public class DeckBuilderPageMap
    {
        public Element CopyDeckIcon => Driver.FindElement(By.CssSelector(".copyButton"), "Copy Deck Icon");

        public Element AddCardsManuallyLink => Driver.FindElement(By.XPath("//a[text()='add cards manually']"), "Add Cards Manually Link");
    }
}
