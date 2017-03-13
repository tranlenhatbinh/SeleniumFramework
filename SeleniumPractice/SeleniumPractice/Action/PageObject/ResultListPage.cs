using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumPractice.Action.PageObject
{
    public class ResultListPage: GeneralPage
    {   //
        IWebDriver driver;

        public ResultListPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void selectItemCheckBox(IWebDriver driver, string item)
        {
            TickCheckbox(driver, item);
        }

        ////update

        public void expandItemInResultList(IWebDriver driver, string showmorelink)
        {
            ClickControl(driver, showmorelink);
        }





    }
}
