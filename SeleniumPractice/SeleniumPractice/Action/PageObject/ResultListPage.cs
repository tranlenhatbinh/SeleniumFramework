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

        public void selectClusters(IWebDriver driver, string locator, string itemCluster)
        {
            if (DoesElementPresent(driver, itemCluster))
            {
                selectCluster(driver, itemCluster);
            }
            else
            {
                selectCluster(driver, locator);
                selectCluster(driver, itemCluster);
            }
        }

        public void selectShowMore(IWebDriver driver, string locator)
        {
            string[] control = GetControlValue(locator);
            string dynamicControl = control[1].ToString();
            string showmore = string.Format("//a[@id='{0}']/..//a[.='Show More']", dynamicControl);
            if (driver.FindElement(By.XPath(showmore)).Displayed)
            {
                driver.FindElement(By.XPath(showmore)).Click();
            }
            else
            {
                selectCluster(driver, locator);
                driver.FindElement(By.XPath(showmore)).Click();
            }
        }

        public void getvalue(IWebDriver driver, string locator)
        {
            FindWebElement(driver, locator);
        }
    }
}
