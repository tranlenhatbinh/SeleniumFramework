using System.Configuration;

namespace SeleniumPractice.Common
{
    public  class TestData
    {
        public static string browser = ConfigurationManager.AppSettings["browser"];
        public static string ebscodURL = ConfigurationManager.AppSettings["url"];
        public static string searchTerm = "test";
    }
}
