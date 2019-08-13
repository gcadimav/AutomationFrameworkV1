using OpenQA.Selenium;

namespace PageObjectLibrary.Base
{
    public class BaseDriver
    {
        private static IWebDriver webDriver;

        public static IWebDriver GetDriver()
        {
            return webDriver;
        }

        public static void SetDriver(IWebDriver driver)
        {
            webDriver = driver;
        }
    }
}
