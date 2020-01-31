using System;
using System.Collections.Generic;
using System.Text;
using Framework.Models;

namespace Framework.Services
{
    public class InMemoryCardService : ICardService
    {
        public Card GetCardByName(string cardName)
        {
            switch(cardName)
            {
                case "Ice Spirit":
                    return new IceSpiritCard();
                case "Mirror":
                    return new MirrorCard();
                default:
                    throw new System.ArgumentException("Card is not available: " + cardName);
            }
        }
    }
}
