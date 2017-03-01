using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumPractice.Action.PageObject
{
    public class ResultList
    {
        IWebDriver driver;

        public ResultList(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
