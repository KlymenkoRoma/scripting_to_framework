using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using System;
using System.IO;
using Royale.Pages;
using Framework.Models;
using Framework.Services;
using Framework.Selenium;
using System.Collections.Generic;
using Framework;
using Royale.Tests.Base;

namespace Royale.Tests
{
    public class CardTests : TestBase
    {
        static IList<Card> apiCards = new APICardService().GetAllCards();

        [Test, Category("cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_is_on_Cards_Page(Card card)
        {
            var cardOnPage = Pages.AllPages.Cards.GoTo().GetCardByName(card.Name);
            Assert.That(cardOnPage.Displayed);
        }

        [Test, Category("cards_details")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_headers_are_correct_on_Cards_Details_Page(Card card)
        {
            Pages.AllPages.Cards.GoTo().GetCardByName(card.Name).Click();

            var cardOnPage = Pages.AllPages.CardDetails.GetBaseCard();

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Type, cardOnPage.Type);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            Assert.AreEqual(card.Rarity, cardOnPage.Rarity);
        }
    }
}