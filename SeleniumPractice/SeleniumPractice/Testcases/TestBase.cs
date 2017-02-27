using SeleniumPractice.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SeleniumPractice.TestCases
{
    [TestClass]
  public class TestBase: ManageBrowser
    {
        [TestInitialize]
        public void TestInitialize()
        {
            OpenBrowser(TestData.browser);
            CommonAction.NavigateToEbscoPage();
        }

        [TestCleanup]
        public void Testcleanup()
        {
            CloseBrowser();
        }
    }
}
