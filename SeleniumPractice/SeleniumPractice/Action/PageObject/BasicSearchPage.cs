using OpenQA.Selenium;

namespace SeleniumPractice.Action.PageObject
{
    public class BasicSearchPage : GeneralPage
    {
        IWebDriver driver;

        public BasicSearchPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void enterSearchTerm(IWebDriver driver, string searchterm)
        {

            enterValue(driver, "search box", searchterm);
        }

        public void selectItemInSearchOption(IWebDriver driver, string item)
        {
            tickCheckbox(driver, item);
        }

        public void conductSearch(IWebDriver driver, string searchterm)
        {
            enterValue(driver, "search box", searchterm);
            clickControl(driver, "search button");
        }
        

    }
}
