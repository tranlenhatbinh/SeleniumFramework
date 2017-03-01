using OpenQA.Selenium;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;
using SeleniumPractice.Common;

namespace SeleniumPractice.PageObject
{
    public class GeneralPage:CommonAction
    {
        ///<summary>
        /// Method to get the class name from a method
        ///</summary>
        public static string GetClassCaller( int level=4)
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


        public string [] GetControlValue(string namecontrol)
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
                case "ResultList":
                    content = File.ReadAllText(path + @"\Interfaces\ResultList.json");
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
        public IWebElement FindWebElement(string locator)
        {
            string[] control = GetControlValue(locator);
            switch (control[0].ToUpper())
            {
                case "ID":
                    return ManageBrowser.driver.FindElement(By.Id(control[1]));
                case "NAME":
                    return ManageBrowser.driver.FindElement(By.Name(control[1]));
                case "CLASSNAME":
                    return ManageBrowser.driver.FindElement(By.ClassName(control[1]));
                default:
                    return ManageBrowser.driver.FindElement(By.XPath(control[1]));
            }
        }

        public void ClickControl(string locator)
        {
            FindWebElement(locator).Click();
        }
        public void EnterValue(string locator, string value)
        {
            FindWebElement(locator).Clear();
            FindWebElement(locator).SendKeys(value);
        }

        public void TickCheckbox(string locator)
        {
            if (FindWebElement(locator).Selected == false)
            {
               
                FindWebElement(locator).Click();
            }
        }

     


    }
}
