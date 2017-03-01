using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumPractice.PageObject
{
    public class AdvanceSearchPage : GeneralPage
    {
        IWebDriver driver;

        public AdvanceSearchPage(IWebDriver driver)
         {
            this.driver = driver;
         }

        public void ConductAdvanceSearch(IWebDriver driver, string locator, string searchterm, string operatorterm) {
        }

    }
}
