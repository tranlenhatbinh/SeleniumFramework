using SeleniumPractice.Action.Common;
using OpenQA.Selenium;
using System;

namespace SeleniumPractice.Action.PageObject
{
    public class GeneralPage : CommonAction
    {

        public void clickItem(IWebDriver driver, string locator)
        {
            clickControl(driver, locator);
        }

        public void selectSourceTypeOrCluster(IWebDriver driver, string sourceTypeOrCluster, string item, string button)
        {
            string id = getAttributeControl(driver, sourceTypeOrCluster);

            string showmorexpath = "//a[@id='" + id + "']/following-sibling::div/div/a[contains(text(),'Show More')]";
            string itemxpath = "//a[@id='" + id + "']/following-sibling::div//a[contains(text(),'" + item + "')]";

            if (doesElementPresentXpath(driver, itemxpath))
            {
                tickCheckboxXpath(driver, itemxpath);
            }
            else
            {
                sleep(1);

                clickControl(driver, sourceTypeOrCluster);

                if (doesElementPresentXpath(driver, itemxpath))
                {
                    tickCheckboxXpath(driver, itemxpath);
                }
                
                else
                {
                    clickControlXpath(driver, showmorexpath);

                    sleep(1);

                    tickCheckboxXpath(driver, "//a[contains(text(),'" + item + "')]/ancestor::td/preceding-sibling::td/input[@type='checkbox']");

                    sleep(1);

                    if (button!=null)
                    {
                        clickControlXpath(driver, "//span[@class='save-cancel-buttons']/input[@value='" + button + "']");
                    }
                    
                }

            }
 
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
