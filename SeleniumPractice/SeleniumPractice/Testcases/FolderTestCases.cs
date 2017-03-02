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
        }

        [TestCleanup]
        public void Testcleanup()
        {
            CloseBrowser(driver);
        }
    }
}
