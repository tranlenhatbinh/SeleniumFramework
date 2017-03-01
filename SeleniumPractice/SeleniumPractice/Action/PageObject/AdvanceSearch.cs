using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumPractice.Action.PageObject
{
    public class AdvanceSearch : GeneralPage
    {
        IWebDriver driver;

        public AdvanceSearch(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
