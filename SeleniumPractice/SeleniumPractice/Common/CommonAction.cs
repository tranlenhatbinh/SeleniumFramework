using OpenQA.Selenium;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;

namespace SeleniumPractice.Common
{
    public class CommonAction
    {
          ///<summary>
        /// Method to get the class name from a method
        ///</summary>
        public static string GetClassCaller(int level = 4)
        {
            var m = new StackTrace().GetFrame(level).GetMethod();
            string classname = m.DeclaringType.Name;
            return classname;
        }

        public class control
        {
            public string controlName { get; set; }
            public string type { get; set; }
            public string value { get; set; }
        }


        public string[] GetControlValue(string namecontrol)
        {
            string page = GetClassCaller();
            string path = Directory.GetParent(System.Reflection.Assembly.GetExecutingAssembly().Location).FullName;
            path = path.Replace("\\bin\\Debug", "");
            string content = string.Empty;
            switch (page)
            {
                case "BasicSearch":
                    content = File.ReadAllText(path + @"\Interfaces\BasicSearch.json");
                    break;
                case "GeneralPage":
                    content = File.ReadAllText(path + @"\Interfaces\GeneralPage.json");
                    break;
                default:
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
            return null;
        }

        ///<summary>
        /// Method to find a web element
        ///</summary>
        public IWebElement FindWebElement(IWebDriver driver, string locator)
        {
            string[] control = GetControlValue(locator);
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

        public void ClickControl(IWebDriver driver, string locator)
        {
            FindWebElement(driver, locator).Click();
        }

        public void EnterValue(IWebDriver driver, string locator, string value)
        {
            FindWebElement(driver, locator).Clear();
            FindWebElement(driver, locator).SendKeys(value);
        }

        public void TickCheckbox(IWebDriver driver, string locator)
        {
            if (FindWebElement(driver, locator).Selected == false)
            {

                FindWebElement(driver, locator).Click();
            }
        }

    }
}
