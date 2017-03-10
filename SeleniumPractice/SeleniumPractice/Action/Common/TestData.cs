using System.Configuration;

namespace SeleniumPractice.Action.Common
{
    public class TestData
    {
        public static string browser = ConfigurationManager.AppSettings["browser"];
        public static string ebscodURL = ConfigurationManager.AppSettings["url"];
        public static string searchTerm = "test";
        public static string runtype = ConfigurationManager.AppSettings["run type"];
        private static string FirefoxVersion = ConfigurationManager.AppSettings["FirefoxVersion"];
        private static string firefoxPlatform = ConfigurationManager.AppSettings["FirefoxPlatform"];
    }
}
