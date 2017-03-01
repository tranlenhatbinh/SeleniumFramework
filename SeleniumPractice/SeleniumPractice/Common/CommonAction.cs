using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace SeleniumPractice.Common
{
   public class CommonAction: ManageBrowser
    {
        // move to managebrowser
        public static void NavigateToEbscoPage()
        {
            ManageBrowser.driver.Navigate().GoToUrl(TestData.ebscodURL);
        }
        // Enter, click, verifytext

    }
}
