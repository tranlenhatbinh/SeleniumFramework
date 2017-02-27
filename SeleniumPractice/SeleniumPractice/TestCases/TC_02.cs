using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumPractice.PageObject;
using System.Threading;


namespace SeleniumPractice.TestCases
{
    [TestClass]
  public  class TC_02: GeneralPage
    {
        [TestInitialize]
        public void TestInitialize()
        {
            OpenBrowser("firefox");
        }

        [TestMethod]
        public void TC_002()
        {
            BasicSearch basicsearchpage = new BasicSearch();
            basicsearchpage = NavigateToEbscoPage();
            Thread.Sleep(1);
            basicsearchpage.EnterSearchTern("test");      
            basicsearchpage.ClickSearchOption();
            //select limiter and expander
            //basicsearchpage.SelectItemInSe       archOption("Peer Reviewed limiter");
           basicsearchpage.SelectItemInSearchOption("Apply related words expander");
        }
    }
}
