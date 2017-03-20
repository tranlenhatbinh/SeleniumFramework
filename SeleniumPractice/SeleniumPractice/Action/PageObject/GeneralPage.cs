using SeleniumPractice.Action.Common;
using OpenQA.Selenium;
using System;

namespace SeleniumPractice.Action.PageObject
{
    public class GeneralPage : CommonAction
    {

        public void clickSearchButton(IWebDriver driver)
        {
            ClickControl(driver, "search button");
        }

        public void selectCluster(IWebDriver driver, string locator)
        {
            FindWebElement(driver, locator).Click();
        }

        public bool DoesElementPresent(IWebDriver driver,string locator)
        {
            try
            {
                return FindWebElement(driver,locator).Displayed;
            }

            catch (NoSuchElementException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
