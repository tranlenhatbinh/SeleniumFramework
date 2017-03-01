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

    }
}
