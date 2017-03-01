using SeleniumPractice.Common;
using OpenQA.Selenium;

namespace SeleniumPractice.PageObject
{
    public class GeneralPage : CommonAction
    {

        public void clickSearchButton(IWebDriver driver)
        {
            ClickControl(driver, "search button");
        }

    }
}
