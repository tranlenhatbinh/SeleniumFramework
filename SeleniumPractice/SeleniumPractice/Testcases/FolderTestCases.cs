using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumPractice.Action.PageObject;
using SeleniumPractice.Action.Common;

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
            driver = openBrowser(driver, TestData.browser);
            navigateToEbscoPage(driver);
        }

        [TestMethod]
        public void TC01_Folder()
        {
            // 1. Conduct a Search term on basic search textbox
            basicSearch = new BasicSearchPage(driver);
            basicSearch.conductSearch(driver, TestData.searchTerm);
            // 2. Check 'Full Text' limiter checkbox from Result list
            resultList = new ResultListPage(driver);
        }

        [TestCleanup]
        public void Testcleanup()
        {
            updateResultSauceLabs(driver);
            closeBrowser(driver);
        }
    }
}
