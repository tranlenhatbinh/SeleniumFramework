using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumPractice.Action.Common;
using SeleniumPractice.Action.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumPractice.Action.PageObject
{
    public class BasicSearchPage : GeneralPage
    {   //
        IWebDriver driver;

        public BasicSearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClickSearchOption(IWebDriver driver)
        {
            ClickControl(driver, "search options");
        }

        public void EnterSearchTerm(IWebDriver driver, string searchterm)
        {

            EnterValue(driver, "search box", searchterm);
        }

        public void SelectItemInSearchOption(IWebDriver driver, string item)
        {
            //
            TickCheckbox(driver, item);
        }

        public void ConductSearch(IWebDriver driver, string searchterm)
        {
            EnterValue(driver, "search box", searchterm);
            ClickControl(driver, "search button");
        }

       
    }
}
