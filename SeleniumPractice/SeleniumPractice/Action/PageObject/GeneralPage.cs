using SeleniumPractice.Action.Common;
using OpenQA.Selenium;
using System;

namespace SeleniumPractice.Action.PageObject
{
    public class GeneralPage : CommonAction
    {

       // public void clickSearchButton(IWebDriver driver)
      //  {
      //      ClickControl(driver, "search button");
      //  }

       // thi update
        public void clickItem(IWebDriver driver, string item)
        {
            ClickControl(driver, item);

        }

        public void SelectItemCluster(IWebDriver driver, string cluser)
        {
            //Showmorexpath is based on Idcluster, so we have to get attributeid from element, them add in
            //Dynamid xpath to build showmorexpath
            string idcluster = GetAttributeID(driver, cluser);
            Console.WriteLine(idcluster);
            string showmorexpath = "//div[@id='"+idcluster+"']//a[text()='Show More']";
            Console.WriteLine(showmorexpath);
            if (DoesElementPresent(driver, showmorexpath))
           {

                clickItem(driver, showmorexpath);
           }
            else
            {
                clickItem(driver, cluser);
                clickItem(driver, showmorexpath);
            }
        }



        //select item cluster in showmoremodal
        public void SelectItemClusterInShowmoreModal(IWebDriver driver, string cluser, string itemcluster)
        {
            //Showmorexpath is based on Idcluster, so we have to get attributeid from element, them add in
            //Dynamid xpath to build showmorexpath
            string idcluster = GetAttributeID(driver, cluser);
            Console.WriteLine(idcluster);
            string showmorexpath = "//div[@id='" + idcluster + "']//a[text()='Show More']";
            Console.WriteLine(showmorexpath);

            if (DoesElementPresent(driver, showmorexpath))
            {
                clickItem(driver, showmorexpath);
            }
            else
            {
                clickItem(driver, cluser);
                clickItem(driver, showmorexpath);
            }

            string a = "//div[@id='multiSelectDbFilter']//table/tbody//tr/td//a[text()='NewsBank']/..//..//../td[1]/input";
            //truyen id cluster parent and text of specific itemcluster need selecting
            string realitemcluster = "//div[@id='" + idcluster + "']//table/tbody//tr/td//a[text()='"+itemcluster+"']/..//..//../td[1]/input";
            clickItem(driver, realitemcluster);
        }
    }
}
