using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using Framework.Models;
using Framework.Selenium;

namespace Royale.Pages
{
    public class CardDetailsPage : PageBase
    {
        public readonly CardDetailsPageMap Map;

        public CardDetailsPage()
        {
            Map = new CardDetailsPageMap();
        }

        public (string Category, string Arena) GetCardCategory()
        {
            var categories = Map.CardCategory().Text.Split(',');
            return (categories[0].Trim(), categories[1].Trim());
        }

        public Card GetBaseCard()
        {
            var (category, arena) = GetCardCategory();

            return new Card
            {
                Name = Map.CardName().Text,
                Rarity = Map.CardRarity().Text,
                Type = category,
                Arena = arena
            };
        }
    }

    public class CardDetailsPageMap
    {
        public IWebElement CardName() { return Driver.FindElement(By.CssSelector("div[class*='cardName']")); }
        public IWebElement CardCategory() { return Driver.FindElement(By.CssSelector("div[class*='card__rarity']")); }
        public IWebElement CardRarity() { return Driver.FindElement(By.CssSelector("[class*='card__count'] > span")); }
    }
}
