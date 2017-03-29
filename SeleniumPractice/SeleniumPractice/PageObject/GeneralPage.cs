using OpenQA.Selenium;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Web.Script.Serialization;
using SeleniumPractice.Common;

namespace SeleniumPractice.PageObject
{
    public class GeneralPage : CommonAction
    {
        public void ClickSearchButton(IWebDriver driver, string locator )
        {
            ClickControl(driver, locator);
        }

    }
}
