using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;

namespace Royale.Pages
{
    public abstract class PageBase
    {
        public readonly HeaderNav HeaderNav;

        public PageBase()
        {
            HeaderNav = new HeaderNav();
        }
    }
}
