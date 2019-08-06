using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using PageObjectLibrary.PageObjects.AutomationPractice.ContactUs;
using PageObjectLibrary.PageObjects.AutomationPractice.Menu;
using PageObjectLibrary.Steps.AutomationPractice.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class TestClass
    {
        //1. unit testing framework: MSTest v2
        //mstest framework & mstest adapter

        //2. automation framework: Selenium web driver
        //selenium driver & selenium support

        //3. practice site: http://automationpractice.com/index.php

        //4. download chrome driver and move it to a folder

        //5. test coding

        //assembly initialize
        //class initialize
        //Test initialize
        //test 
        //test teardown
        //class teardown
        //assembly teardown

        IWebDriver webDriver;
        NavigationSteps navigationSteps;


        [TestMethod]
        public void ContactUsFormIsSentWithValidData()
        {
            ContactUsPage contactUsPage = navigationSteps.GoToContactUsPage();            
            contactUsPage.FillContactUsForm(ContactUsPage.Options.ByText, "Customer service", "daniel.terceros@test.com",
                "1234", @"C:\File.txt", "My product did not arrive as expected");

            string actualMessage = contactUsPage.GetConfirmationLabel();
            string expectedMessage = "Your message has been successfully sent to our team.";
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestMethod]
        public void ContactUsFormIsNotSentWithInvalidData()
        {
            ContactUsPage contactUsPage = navigationSteps.GoToContactUsPage();
            contactUsPage.FillContactUsForm(ContactUsPage.Options.ByText, "Customer service", "invalid email",
                "1234", @"C:\File.txt", "My product did not arrive as expected");

            string actualMessage = contactUsPage.GetErrorLabel();
            string expectedMessage = "Invalid email address.";
            Assert.AreEqual(expectedMessage, actualMessage);
        }

        [TestInitialize]
        public void TestSetup()
        {
            webDriver = new ChromeDriver(@"C:\SeleniumWebDrivers");
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            webDriver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            navigationSteps = new NavigationSteps(webDriver);
        }

        [TestCleanup]
        public void TestTearDown()
        {
            webDriver.Close();
            webDriver.Quit();
        }
    }
}
