using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Diagnostics;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Remote;
using System.Configuration;

namespace SeleniumPractice.Action.Common
{
    public class ManageBrowser
    {
        public IWebDriver OpenBrowser(IWebDriver driver, string browsername)
        {
            if (TestData.runtype.ToUpper() == "LOCAL")
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
            else if (TestData.runtype.ToUpper() == "SAUCELAB")
            {
                switch (browsername.ToUpper())
                {
                    case "FIREFOX":
                        driver = driverRunOnSauceLabs("firefox", TestData.FirefoxVersion, TestData.firefoxPlatform);
                        break;
                    case "CHROME":
                        driver = driverRunOnSauceLabs("Chrome", TestData.ChromeVersion, TestData.chromePlatform);
                        break;
                    case "IE":
                        driver = driverRunOnSauceLabs("Internet Explorer", TestData.IEVersion, TestData.iePlatform);
                        break;
                    default:
                        driver = driverRunOnSauceLabs("firefox", TestData.FirefoxVersion, TestData.firefoxPlatform);
                        break;
                }
            }
            return driver;
        }

        private static IWebDriver driverRunOnSauceLabs(string browser, string version, string platform)
        {
            var uri = new Uri("http://ondemand.saucelabs.com:80/wd/hub");
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.BrowserName, browser);
            caps.SetCapability(CapabilityType.Version, version);
            caps.SetCapability(CapabilityType.Platform, platform);
            caps.SetCapability("username", ConfigurationManager.AppSettings["usernameSauceLabs"]);
            caps.SetCapability("accessKey", ConfigurationManager.AppSettings["accessKeySauceLabs"]);
           // caps.SetCapability("name", TestContext.CurrentContext.Test.Name);
            return new RemoteWebDriver(uri, caps, TimeSpan.FromSeconds(600));
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
