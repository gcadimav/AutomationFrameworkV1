using PageObjectLibrary.Base;
using PageObjectLibrary.PageObjects.AutomationPractice;
using PageObjectLibrary.PageObjects.AutomationPractice.ContactUs;

namespace PageObjectLibrary.Steps.AutomationPractice.Navigation
{
    public class NavigationSteps: BaseStep
    {
        public NavigationSteps()
        {
            NavigateToInitialSite();
        }

        public ContactUsPage GoToContactUsPage()
        {            
            var homePage = new HomePage();
            var contactUsPage = homePage.ClickContactUs();            
            return contactUsPage;
        }
    }
}
