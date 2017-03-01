using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Diagnostics;
using OpenQA.Selenium;

namespace SeleniumPractice.Action.Common
{
    public class ManageBrowser
    {
        public IWebDriver OpenBrowser(IWebDriver driver, string browsername)
        {
            switch (browsername.ToUpper())
            {
                case "CHROME":
                    driver = new ChromeDriver();
                    driver.Manage().Window.Maximize();
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    driver.Manage().Window.Maximize();
                    break;
                case "FIREFOX":
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    break;
                default:
                    driver = new FirefoxDriver();
                    driver.Manage().Window.Maximize();
                    break;
            }
            return driver;
        }

        // move to managebrowser
        public static void NavigateToEbscoPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(TestData.ebscodURL);
        }

        public static void CloseBrowser(IWebDriver driver)
        {
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Quit();
            foreach (Process process in Process.GetProcessesByName("iexplore"))
            {
                process.Kill();
            }

        }

    }
}
