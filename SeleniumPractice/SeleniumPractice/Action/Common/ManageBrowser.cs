using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Diagnostics;
using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Remote;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumPractice.Action.Common
{
    public class ManageBrowser
    {
        public IWebDriver openBrowser(IWebDriver driver, string browsername)
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
        public  TestContext TestContext { get; set; }
        private  IWebDriver driverRunOnSauceLabs(string browser, string version, string platform)
        {  
            var uri = new Uri("http://ondemand.saucelabs.com:80/wd/hub");
            DesiredCapabilities caps = new DesiredCapabilities();
            caps.SetCapability(CapabilityType.BrowserName, browser);
            caps.SetCapability(CapabilityType.Version, version);
            caps.SetCapability(CapabilityType.Platform, platform);
            caps.SetCapability("username", ConfigurationManager.AppSettings["usernameSauceLabs"]);
            caps.SetCapability("accessKey", ConfigurationManager.AppSettings["accessKeySauceLabs"]);
            caps.SetCapability("name", TestContext.TestName);
            return new RemoteWebDriver(uri, caps, TimeSpan.FromSeconds(600));
        }

        public void updateResultSauceLabs(IWebDriver driver)
        {   
            if(TestData.runtype.ToUpper() == "SAUCELAB")
            { 
            bool passed = TestContext.CurrentTestOutcome == UnitTestOutcome.Passed;
           ((IJavaScriptExecutor)driver).ExecuteScript("sauce:job-result=" + (passed ? "passed" : "failed"));
            }
        }
        
        // move to managebrowser
        public static void navigateToEbscoPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(TestData.ebscodURL);
        }

        public static void closeBrowser(IWebDriver driver)
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
