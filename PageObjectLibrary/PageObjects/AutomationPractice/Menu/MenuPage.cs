using OpenQA.Selenium;
using PageObjectLibrary.PageObjects.AutomationPractice.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectLibrary.PageObjects.AutomationPractice.Menu
{
    public class MenuPage
    {

        IWebDriver webDriver;

        public MenuPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        
        public ContactUsPage ClickContactUs()
        {
            IWebElement contactUsButton = webDriver.FindElement(By.XPath("//a[@title='Contact Us']"));
            contactUsButton.Click();
            ContactUsPage contactUsPage = new ContactUsPage(webDriver);
            return contactUsPage;
        }
    }
}
