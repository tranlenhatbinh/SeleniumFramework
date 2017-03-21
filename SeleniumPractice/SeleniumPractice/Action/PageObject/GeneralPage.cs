using SeleniumPractice.Action.Common;
using OpenQA.Selenium;

namespace SeleniumPractice.Action.PageObject
{
    public class GeneralPage : CommonAction
    {

        public void clickSearchButton(IWebDriver driver)
        {
            ClickControl(driver, "search button");
        }

        public void selectSourceType(IWebDriver driver, string sourceType, string item, string button)
        {
            string id = getAttributeControl(driver, sourceType);
            
            if(checkControlDisplay(driver, sourceType) == false)
            {
                ClickControl(driver, sourceType);
            }
            ClickControlXpath(driver, "//a[@id='" + id + "']/following-sibling::div/div/a[contains(text(),'Show More')]");

            Sleep(1);

            if (item != null)
            {
                TickCheckboxXpath(driver, "//a[contains(text(),'" + item + "')]/ancestor::td/preceding-sibling::td/input[@type='checkbox']");
            }

            Sleep(1);

           ClickControlXpath(driver, "//span[@class='save-cancel-buttons']/input[@value='"+ button +"']");
        }

    }
}
