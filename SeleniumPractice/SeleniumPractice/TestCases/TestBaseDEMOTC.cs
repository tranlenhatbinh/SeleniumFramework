using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumPractice.Common;

namespace SeleniumPractice.TestCases
{
    [TestClass]
   public class TestBaseDEMOTC:CommonAction
    {
        [AssemblyInitialize]
        public static void AssemblyInitializeMeThod(TestContext TestContext)
        {
            OpenBrowser("Chrome");
        }

        [AssemblyCleanup]
        public static void AssemblyCleapUpMethod()
        {
            CloseBrowser();
        }
        [TestInitialize]

        public static void TestInitialize()
        {
            NavigateToEbscoPage();
        }
    }
}
