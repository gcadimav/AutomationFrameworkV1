using OpenQA.Selenium;
using PageObjectLibrary.Base;
using PageObjectLibrary.PageObjects.AutomationPractice.ContactUs;

namespace PageObjectLibrary.PageObjects.AutomationPractice.Menu
{
    public class MenuPage: BasePage
    {
        private IWebElement contactUsButton => GetDriver().FindElement(By.XPath("//a[@title='Contact Us']"));        
        
        public ContactUsPage ClickContactUs()
        {
            contactUsButton.Click();
            var contactUsPage = new ContactUsPage();
            return contactUsPage;
        }
    }
}
