using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumPractice.Common;
using SeleniumPractice.PageObject;

using OpenQA.Selenium;


namespace SeleniumPractice.TestCases
{
    [TestClass]
    public class BreadboxTestCases : ManageBrowser
    {
        IWebDriver driver;
        private BasicSearch basicsearch;


        [TestInitialize]
        public void TestInitialize()
        {
            driver = OpenBrowser(driver, TestData.browser);
            NavigateToEbscoPage(driver);
        }

        [TestMethod]
        public void TC2_Verify_that_Clear_All_link_removes_all_items_from_search()
        {
            basicsearch = new BasicSearch(driver);
            basicsearch.EnterSearchTerm(driver, TestData.searchTerm);
          //  basicsearch.ClickSearchOption(driver);
          //  basicsearch.SelectItemInSearchOption(driver, "Full Text limiter");
          //  basicsearch.SelectItemInSearchOption(driver, "Peer Reviewed limiter");
            basicsearch.ClickSearchButton(driver, "search button");
        }

        [TestCleanup]
        public void Testcleanup()
        {
            //CloseBrowser(driver);

        }
    }
}
