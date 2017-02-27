using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumPractice.Common;
using SeleniumPractice.PageObject;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumPractice.PageObject
{
   public class BasicSearch: GeneralPage
    {
        public void ClickSearchOption()
        {
            ClickControl("search options");
        }

        public void EnterSearchTern(string searchterm)
        {
          
            EnterValue("search box", searchterm);
        }

        public void SelectItemInSearchOption(string item)
        {
          
            TickCheckbox(item);
        }
    }
}
