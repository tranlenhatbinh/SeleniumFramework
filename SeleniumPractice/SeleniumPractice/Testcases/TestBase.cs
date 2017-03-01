using SeleniumPractice.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumPractice.TestCases
{
    [TestClass]
  public class TestBase: ManageBrowser
    {
       IWebDriver driver;
        //
        //public static IWebDriver getdriver()
        //{
        //    return driver = OpenBrowser(driver, TestData.browser);
        //}
        [TestInitialize]
        public void TestInitialize()
        {
            driver = OpenBrowser(driver, TestData.browser);
            NavigateToEbscoPage(driver);

        }
        [TestCleanup]
        public void Testcleanup()
        {
            CloseBrowser(driver);
        }
    }
}
