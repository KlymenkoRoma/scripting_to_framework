using System;
using System.Collections.Generic;
using System.Text;
using Framework.Models;

namespace Framework.Services
{
    public interface ICardService
    {
        Card GetCardByName(string cardName);
    }
}
