using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Diagnostics;
using OpenQA.Selenium;

namespace SeleniumPractice.Common
{
    public class ManageBrowser
    {
        public static IWebDriver driver;
        public static void OpenBrowser(string browsername)
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
        }

        public static void CloseBrowser()
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
