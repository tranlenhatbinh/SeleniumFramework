using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System.Diagnostics;
using SeleniumPractice.Common;

namespace SeleniumPractice.Common
{
   public class ManageBrowser
    {
      
        public static void OpenBrowser( string browsername)
        {
            switch (browsername.ToUpper())
            {
                case "CHROME":
                   CommonAction.WebDriver.driver = new ChromeDriver();
                    CommonAction.WebDriver.driver.Manage().Window.Maximize();
                    break;
                case "IE":
                    CommonAction.WebDriver.driver = new InternetExplorerDriver();
                    CommonAction.WebDriver.driver.Manage().Window.Maximize();
                    break;
                case "Firefox":
                    CommonAction.WebDriver.driver = new FirefoxDriver();
                    CommonAction.WebDriver.driver.Manage().Window.Maximize();
                    break;
                default:
                    CommonAction.WebDriver.driver = new FirefoxDriver();
                    CommonAction.WebDriver.driver.Manage().Window.Maximize();
                    break;
            }
           
        }

        public static void CloseBrowser()
        {
            CommonAction.WebDriver.driver.Manage().Cookies.DeleteAllCookies();
            CommonAction.WebDriver.driver.Quit();
            foreach (Process process in Process.GetProcessesByName("iexplore"))
            {
                process.Kill();
            }
        
        }

       
    }
}
