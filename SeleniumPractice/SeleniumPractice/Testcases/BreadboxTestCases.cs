using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumPractice.Action.Common;
using SeleniumPractice.Action.PageObject;

using OpenQA.Selenium;


namespace SeleniumPractice.TestCases
{
    [TestClass]
    public class BreadboxTestCases : ManageBrowser
    {
        IWebDriver driver;
        private BasicSearchPage basicsearch;
        private ResultListPage resultlist;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = openBrowser(driver, TestData.browser);
            navigateToEbscoPage(driver);
        }

        [TestMethod]
        public void TC2_Verify_that_Clear_All_link_removes_all_items_from_search()
        {
            basicsearch = new BasicSearchPage(driver);
            resultlist = new ResultListPage(driver);
            basicsearch.enterSearchTerm(driver, TestData.searchTerm);
            basicsearch.clickItem(driver, "search options");
            basicsearch.selectItemInSearchOption(driver, "Full Text limiter");
            basicsearch.selectItemInSearchOption(driver, "Peer Reviewed limiter");
            basicsearch.selectItemInSearchOption(driver, "Apply related words expander");
            basicsearch.clickItem(driver, "search button");
            resultlist.selectSourceTypeOrCluster(driver, "publication cluster", "child development", "Update");
            resultlist.selectSourceTypeOrCluster(driver, "source type", "Academic Journals", null);
            resultlist.selectSourceTypeOrCluster(driver, "language cluster", "english", null);
         
        }

        [TestCleanup]
        public void Testcleanup()
        {
            //closeBrowser(driver);

        }
    }
}
