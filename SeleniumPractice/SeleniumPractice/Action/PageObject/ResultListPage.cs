using OpenQA.Selenium;
using SeleniumPractice.Action.Common;

namespace SeleniumPractice.Action.PageObject
{
    public class ResultListPage : GeneralPage
    {
        IWebDriver driver;

        public ResultListPage(IWebDriver driver)
        {
            this.driver = driver;
        }

    }
}
