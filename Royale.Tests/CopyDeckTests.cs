using Framework.Selenium;
using Framework;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using Royale.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Royale.Tests.Base;

namespace Royale.Tests
{
    public class CopyDeckTests : TestBase
    {
        [Test, Category("copydeck")]
        public void User_can_copy_the_deck()
        {
            AllPages.DeckBuilder.GoTo().AddCardsManually();
            AllPages.DeckBuilder.CopySuggestedDeck();
            AllPages.CopyDeck.Yes();
            Assert.That(AllPages.CopyDeck.Map.CopiedMessage.Displayed);
        }

        [Test, Category("copydeck")]
        public void User_opens_app_store()
        {
            AllPages.DeckBuilder.GoTo().AddCardsManually();
            AllPages.DeckBuilder.CopySuggestedDeck();
            AllPages.CopyDeck.No().OpenAppStore();

            var title = Regex.Replace(Driver.Title, @"\u0200e", string.Empty);

            Assert.That(Driver.Title, Is.EqualTo("Clash Royale on the App Store"));
        }

        [Test, Category("copydeck")]
        public void User_opens_google_play()
        {
            AllPages.DeckBuilder.GoTo().AddCardsManually();
            AllPages.DeckBuilder.CopySuggestedDeck();
            AllPages.CopyDeck.No().OpenGooglePlay();
            Assert.AreEqual(Is.EqualTo("Clash Royale - Apps on Google Play"), Driver.Title);
        }
    }
}
