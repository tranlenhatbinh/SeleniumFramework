using OpenQA.Selenium;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;
using System.Threading;
using System;

namespace SeleniumPractice.Action.Common
{
    public class CommonAction
    {
          ///<summary>
        /// Method to get the class name from a method
        ///</summary>
        public static string getClassCaller(int level = 4)
        {
            var m = new StackTrace().GetFrame(level).GetMethod();
            string classname = m.DeclaringType.Name;
            return classname;
        }


        public static string a = GetClassCaller();
        public class control
        {
            public string controlName { get; set; }
            public string type { get; set; }
            public string value { get; set; }
        }


        public string[] getControlValue(string namecontrol)
        {
            string page = getClassCaller();
            string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            path = path.Replace("\\bin\\Debug", "");
            string content = string.Empty;
            switch (page)
            {
                case "BasicSearchPage":
                    content = File.ReadAllText(path + @"\Interfaces\BasicSearch.json");
                    break;
                case "GeneralPage":
                    content = File.ReadAllText(path + @"\Interfaces\GeneralPage.json");
                    break;
                case "ResultListPage":
                    content = File.ReadAllText(path + @"\Interfaces\ResultList.json");
                    break;
                default:
                    content = File.ReadAllText(path + @"\Interfaces\ResultList.json");
                    break;
            }
            var result = new JavaScriptSerializer().Deserialize<List<control>>(content);
            string[] control = new string[2];
            foreach (var item in result)
            {
                if (item.controlName.Equals(namecontrol))
                {
                    control[0] = item.type;
                    control[1] = item.value;
                    return control;
                }
            }
            return control;
        }
        
        ///<summary>
        /// Method to find a web element
        ///</summary>
        public IWebElement findWebElement(IWebDriver driver, string locator)
        {
            string[] control = getControlValue(locator);
            switch (control[0].ToUpper())
            {
                case "ID":
                    return driver.FindElement(By.Id(control[1]));
                case "NAME":
                    return driver.FindElement(By.Name(control[1]));
                case "CLASSNAME":
                    return driver.FindElement(By.ClassName(control[1]));
                default:
                    return driver.FindElement(By.XPath(control[1]));
            }
        }

        public IWebElement findWebElementXpath(IWebDriver driver, string xpath)
        {
            return driver.FindElement(By.XPath(xpath));
        }

        public void clickControlXpath(IWebDriver driver, string xpath)
        {
            findWebElementXpath(driver, xpath).Click();
        }

        public void clickControl(IWebDriver driver, string locator)
        {
            findWebElement(driver, locator).Click();
        }

        public void enterValue(IWebDriver driver, string locator, string value)
        {
            findWebElement(driver, locator).Clear();
            findWebElement(driver, locator).SendKeys(value);
        }

        public void tickCheckbox(IWebDriver driver, string locator)
        {
            if (findWebElement(driver, locator).Selected == false)
            {

                findWebElement(driver, locator).Click();
            }
        }

        public void tickCheckboxXpath(IWebDriver driver, string xpath)
        {
            if (findWebElementXpath(driver, xpath).Selected == false)
            {

                findWebElementXpath(driver, xpath).Click();
            }
        }

        ///<summary>
        /// Method to check whether element presents or not
        ///</summary>
        public bool doesElementPresent(IWebDriver driver, string locator)
        {
            try
            {
                return findWebElement(driver, locator).Displayed;
            }

            catch (NoSuchElementException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public bool doesElementPresentXpath(IWebDriver driver, string xpath)
        {
            try
            {
                return findWebElementXpath(driver, xpath).Displayed;
            }

            catch (NoSuchElementException e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public string getAttributeControl (IWebDriver driver, string locator)
        {
            string id = findWebElement(driver, locator).GetAttribute("id").ToString();
            return id;
        }

        ///<summary>
        /// Method to perform sleep action in specific seconds
        ///</summary>
        public void sleep(int second)
        {
            Thread.Sleep(second * 1000);
        }

        /// <summary>
        /// Method to wait for control by locator
        /// </summary>
        public void waitForControl(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            IWebElement element;
            bool check = false;
            for (int i = 0; i < timeoutInSeconds; i++)
            {
                try
                {
                    element = driver.FindElement(locator);
                    if (element.Displayed != check)
                    {
                        sleep(1);
                        return;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    sleep(1);
                    continue;
                }
            }
        }
    }
}
