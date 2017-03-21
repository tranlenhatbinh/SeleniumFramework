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
        private BasicSearch basicSearch;
        private ResultList resultList;

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
            basicSearch = new BasicSearch(driver);
            basicSearch.conductSearch(driver, TestData.searchTerm);
            // 2. Check 'Full Text' limiter checkbox from Result list
            resultList = new ResultList(driver);
        }

        [TestCleanup]
        public void Testcleanup()
        {
            closeBrowser(driver);
        }
    }
}
