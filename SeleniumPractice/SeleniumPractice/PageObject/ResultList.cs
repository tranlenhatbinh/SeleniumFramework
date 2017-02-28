using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPractice.PageObject
{
public class ResultList:GeneralPage
    {
        public void goToContentProvider()
        {
            ClickControl("Contain Provider cluster");
            ClickControl("Show More Contain Provider cluster");
        }
    }
}
