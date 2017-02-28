﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumPractice.PageObject;
using SeleniumPractice.Common;
using System.Threading;

namespace SeleniumPractice.TestCases
{
    [TestClass]
    public class FolderTestCases:TestBase
    {
        private BasicSearch basicSearch;
        private ResultList resultList;
        [TestMethod]
        public void TC01_Folder()
        {
            // 1. Conduct a Search term on basic search textbox
            basicSearch = new BasicSearch();
            basicSearch.ConductSearch(TestData.searchTerm);
            // 2. Check 'Full Text' limiter checkbox from Result list
            resultList = new ResultList();
            resultList.goToContentProvider();
        }
    }
}
