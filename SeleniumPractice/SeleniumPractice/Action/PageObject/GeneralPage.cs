using SeleniumPractice.Action.Common;
using OpenQA.Selenium;

namespace SeleniumPractice.Action.PageObject
{
    public class GeneralPage : CommonAction
    {

       // public void clickSearchButton(IWebDriver driver)
      //  {
      //      ClickControl(driver, "search button");
      //  }

       // thi update
        public void clikcItem(IWebDriver driver, string item)
        {
            ClickControl(driver, item);

        }

    }
}
