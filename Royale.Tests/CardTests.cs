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

namespace Royale.Tests
{
    public class CardTests
    {
        [SetUp]
        public void BeforeEach()
        {
            Driver.Init();
            AllPages.Init();
            Driver.GoTo("statsroyale.com");
            Driver.WindowMaximize();
            //test
        }

        [TearDown]
        public void AfterEach()
        {
            Driver.Quit();
        }

        static string[] cardNames = { "Ice Spirit", "Mirror" };

        [Test, Category("cards")]
        [TestCaseSource("cardNames")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_is_on_Cards_Page(string cardName)
        {
            var card = AllPages.Cards.GoTo().GetCardByName(cardName);
            Assert.That(card.Displayed);
        }

        [Test, Category("cards_details")]
        [TestCaseSource("cardNames")]
        [Parallelizable(ParallelScope.Children)]
        public void Card_headers_are_correct_on_Cards_Details_Page(string cardName)
        {
            AllPages.Cards.GoTo().GetCardByName(cardName).Click();

            var cardOnPage = AllPages.CardDetails.GetBaseCard();
            var card = new InMemoryCardService().GetCardByName(cardName);

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Type, cardOnPage.Type);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            Assert.AreEqual(card.Rarity, cardOnPage.Rarity);
        }
    }
}