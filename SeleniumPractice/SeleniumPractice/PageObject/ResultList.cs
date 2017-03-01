using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumPractice.PageObject
{
    public class ResultList: GeneralPage
    {   //
        IWebDriver driver;

        public ResultList(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectLimiterCheckBox(IWebDriver driver)
        {
            TickCheckbox(driver, "fulltext limiter");
        }
    }
}
