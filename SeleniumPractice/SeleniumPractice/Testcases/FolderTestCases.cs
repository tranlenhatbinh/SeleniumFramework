using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumPractice.Action.PageObject;
using SeleniumPractice.Action.Common;
using System.Threading;

using OpenQA.Selenium;

namespace SeleniumPractice.TestCases

{
    [TestClass]
    public class FolderTestCases : ManageBrowser
    {

        IWebDriver driver;
        private BasicSearchPage basicSearch;
        private ResultListPage resultList;

        [TestInitialize]
        public void TestInitialize()
        {
            driver = OpenBrowser(driver, TestData.browser);
            NavigateToEbscoPage(driver);
        }

        [TestMethod]
        public void TC01_Verify_that_user_is_able_to_delete_fulltext_records_from_folder()
        {
          
            basicSearch = new BasicSearchPage(driver);
            basicSearch.ConductSearch(driver, TestData.searchTerm);            
            resultList = new ResultListPage(driver);
            resultList.clikcItem(driver, "Fulltext limiter");
            resultList.clikcItem(driver, "Contain Provider cluster");
            resultList.clikcItem(driver, "Show More Contain Provider cluster");
            Thread.Sleep(1000);
            resultList.clikcItem(driver, "Business Source Complete cluster");
            resultList.clikcItem(driver, "Update button");
        }

       // [TestCleanup]
        //public void Testcleanup()
       // {
        //    CloseBrowser(driver);
        //}
    }
}
