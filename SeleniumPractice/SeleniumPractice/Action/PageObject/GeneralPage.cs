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

            string showmorexpath = string.Format("//a[@id='{0}']/following-sibling::div//a[.='Show More']", id);
            string itemxpath = string.Format("//a[@id='{0}']/following-sibling::div//a[.='{1}']", id, item);

            if (doesElementPresentXpath(driver, itemxpath))
            {
                tickCheckboxXpath(driver, itemxpath);
            }
            else
            {
                waitForControl(driver, sourceTypeOrCluster, 5);

                clickControl(driver, sourceTypeOrCluster);

                if (doesElementPresentXpath(driver, itemxpath))
                {
                    tickCheckboxXpath(driver, itemxpath);
                }
                
                else
                {
                    clickControlXpath(driver, showmorexpath);

                    waitForControlXpath(driver, "//a[contains(text(),'" + item + "')]/ancestor::td/preceding-sibling::td/input[@type='checkbox']", 5);

                    tickCheckboxXpath(driver, "//a[contains(text(),'" + item + "')]/ancestor::td/preceding-sibling::td/input[@type='checkbox']");

                    if (button!=null)
                    {
                        clickControlXpath(driver, "//span[@class='save-cancel-buttons']/input[@value='" + button + "']");
                    }
                }
            }
        }


    }
}
