using System.Configuration;

namespace SeleniumPractice.Action.Common
{
    public class TestData
    {
        public static string browser = ConfigurationManager.AppSettings["browser"];
        public static string ebscodURL = ConfigurationManager.AppSettings["url"];
        public static string searchTerm = "test";
        public static string runtype = ConfigurationManager.AppSettings["run type"];
        public static string FirefoxVersion = ConfigurationManager.AppSettings["FirefoxVersion"];
        public static string firefoxPlatform = ConfigurationManager.AppSettings["FirefoxPlatform"];
        public static string ChromeVersion = ConfigurationManager.AppSettings["ChromeVersion"];
        public static string chromePlatform = ConfigurationManager.AppSettings["ChromePlatform"];
        public static string IEVersion = ConfigurationManager.AppSettings["IEVersion"];
        public static string iePlatform = ConfigurationManager.AppSettings["IEPlatform"];
    }
}
