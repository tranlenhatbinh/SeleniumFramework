using OpenQA.Selenium;
using SeleniumPractice.Action.Common;

namespace SeleniumPractice.Action.PageObject
{
    public class ResultListPage:GeneralPage
    {
        IWebDriver driver;

        public ResultListPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void selectClusters(IWebDriver driver, string locator)
        {
            //if(DoesElementPresent(driver,locator))
            //{
            //    selectCluster(driver, locator);
            //}
            //else
            //{
            //    string cluster = "//a[@id='multiSelectDocTypeTrigger']";
            //    driver.FindElement(By.XPath(cluster)).Click();
            //    selectCluster(driver, locator);
            //}
            selectCluster(driver, locator);
        }
    }
}
