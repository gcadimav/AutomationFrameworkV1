using Microsoft.VisualStudio.TestTools.UnitTesting;
using PageObjectLibrary.PageObjects.AutomationPractice.ContactUs;
using TestProject.Hooks;

namespace TestProject.Tests
{
    [TestClass]
    public class TestClass: Hook
    { 
        [TestMethod]
        public void ContactUsFormIsSentWithValidData()
        {
            var contactUsPage = navigationSteps.GoToContactUsPage();            
            contactUsPage.FillContactUsForm(ContactUsPage.Options.ByText, "Customer service", "daniel.terceros@test.com",
                "1234", @"C:\testing.txt", "My product did not arrive as expected");

            string actualMessage = contactUsPage.GetConfirmationLabel();
            string expectedMessage = "Your message has been successfully sent to our team.";
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ContactUsFormIsNotSentWithInvalidData()
        {
            var contactUsPage = navigationSteps.GoToContactUsPage();
            contactUsPage.FillContactUsForm(ContactUsPage.Options.ByText, "Customer service", "invalid email",
                "1234", @"C:\testing.txt", "My product did not arrive as expected");

            string actualMessage = contactUsPage.GetErrorLabel();
            string expectedMessage = "Invalid email address.";
            Assert.AreEqual(expectedMessage, actualMessage);
        }       
    }
}
