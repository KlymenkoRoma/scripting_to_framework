using Framework.Selenium;
using Framework;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using Royale.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Royale.Tests
{
    public class CopyDeckTests
    {
        [OneTimeSetUp]
        public void BeforeAll()
        {
            FW.CreateTestResultsDirectory();
        }

        [SetUp]
        public void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init("chrome");
            AllPages.Init();
            Driver.GoTo("statsroyale.com");
            Driver.WindowMaximize();
        }

        [TearDown]
        public void AfterEach()
        {
            Driver.Quit();
        }

        [Test, Category("Copy_deck")]
        public void User_can_copy_the_deck()
        {
            AllPages.DeckBuilder.GoTo().AddCardsManually();
            AllPages.DeckBuilder.CopySuggestedDeck();
            AllPages.CopyDeck.Yes();
            Assert.That(AllPages.CopyDeck.Map.CopiedMessage.Displayed);
        }

        [Test]
        public void User_opens_app_store()
        {
            AllPages.DeckBuilder.GoTo().AddCardsManually();
            AllPages.DeckBuilder.CopySuggestedDeck();
            AllPages.CopyDeck.No().OpenAppStore();

            var title = Regex.Replace(Driver.Title, @"\u0200e", string.Empty);

            Assert.That(Driver.Title, Is.EqualTo("Clash Royale on the App Store"));
        }

        [Test]
        public void User_opens_google_play()
        {
            AllPages.DeckBuilder.GoTo().AddCardsManually();
            AllPages.DeckBuilder.CopySuggestedDeck();
            AllPages.CopyDeck.No().OpenGooglePlay();
            Assert.AreEqual(Is.EqualTo("Clash Royale - Apps on Google Play"), Driver.Title);
        }
    }
}
