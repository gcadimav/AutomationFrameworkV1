using OpenQA.Selenium;
using PageObjectLibrary.PageObjects.AutomationPractice.ContactUs;
using PageObjectLibrary.PageObjects.AutomationPractice.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageObjectLibrary.Steps.AutomationPractice.Navigation
{
    public class NavigationSteps
    {
        IWebDriver webDriver;

        public NavigationSteps(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        public ContactUsPage GoToContactUsPage()
        {
            MenuPage menuPage = new MenuPage(webDriver);
            ContactUsPage contactUsPage = menuPage.ClickContactUs();            
            return contactUsPage;
        }
    }
}
