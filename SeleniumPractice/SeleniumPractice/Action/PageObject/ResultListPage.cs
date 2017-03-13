using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumPractice.Action.PageObject
{
    public class ResultListPage
    {
        IWebDriver driver;

        public ResultListPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
