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
            driver = OpenBrowser(driver, TestData.browser);
            NavigateToEbscoPage(driver);
        }

        [TestMethod]
        public void TC2_Verify_that_Clear_All_link_removes_all_items_from_search()
        {
            basicsearch = new BasicSearchPage(driver);
            basicsearch.EnterSearchTerm(driver, TestData.searchTerm);
            basicsearch.ClickSearchOption(driver);
            basicsearch.SelectItemInSearchOption(driver, "Full Text limiter");
            basicsearch.SelectItemInSearchOption(driver, "Peer Reviewed limiter");
            basicsearch.SelectItemInSearchOption(driver, "Apply related words expander");
            basicsearch.clickSearchButton(driver);
        }

        [TestMethod]
        public void TC3_Verify_that_clicking_Hyperlinked_items_in_the_breadbox_launches_search_for_that_term()
        {
            basicsearch = new BasicSearchPage(driver);
            basicsearch.ConductSearch(driver, TestData.searchTerm);
            resultlist = new ResultListPage(driver);
            //  resultlist.selectItemCluster(driver, "//a[@id='multiSelectDocTypeTrigger']/../div/ul/li/label/a[.='Academic Journals']");
            resultlist.selectClusters(driver, "Contain Provider cluster");
        }

        [TestCleanup]
        public void Testcleanup()
        {
            CloseBrowser(driver);

        }
    }
}
