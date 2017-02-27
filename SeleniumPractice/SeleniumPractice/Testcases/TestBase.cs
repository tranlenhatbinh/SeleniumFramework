using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumPractice.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using SeleniumPractice.PageObject;

namespace SeleniumPractice.TestCases
{
    [TestClass]
  public class TestBase: GeneralPage
    {
      [TestInitialize]
      public void TestInitialize()
        {
            OpenBrowser("firefox");
        }

        [TestMethod]
        public void TC_openbrowser()
        {
        
            NavigateToEbscoPage();
        }

        //[TestCleanup]
        //public void Testcleanup()
        //{
        //    CloseBrowser();
        //}
    }
}
