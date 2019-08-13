using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObjectLibrary.Base
{
    public class BasePage: BaseDriver
    {
        public static WebDriverWait wait;
        public static Actions actions;

        public BasePage()
        {
            wait = new WebDriverWait(GetDriver(),TimeSpan.FromSeconds(10));
            actions = new Actions(GetDriver());
        }
    }
}
