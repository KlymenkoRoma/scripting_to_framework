using Framework.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using Royale.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Royale.Tests
{
    public class CopyDeckTests
    {
        [SetUp]
        public void BeforeEach()
        {
            Driver.Init();
            AllPages.Init();
            Driver.GoTo("statsroyale.com");
            Driver.WindowMaximize();
        }

        [TearDown]
        public void AfterEach()
        {
            Driver.Quit();
        }

        [Test]
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
