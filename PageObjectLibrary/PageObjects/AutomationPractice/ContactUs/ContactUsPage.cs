using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PageObjectLibrary.PageObjects.AutomationPractice.ContactUs
{
    public class ContactUsPage
    {
        IWebDriver webDriver;
        WebDriverWait wait;
        Actions actions;
        public ContactUsPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
            wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            actions = new Actions(webDriver);
        }

        public enum Options
        {
            ByText,
            ByIndex,
            ByValue
        }

        public void SelectSubjectHeading(Options option, string value)
        {
            //Random rnd = new Random();
            //int index = rnd.Next(4); //0-4
            //IList<IWebElement> products = webDriver.FindElements(By.XPath("//div[@class='button-container']/a[@class='button ajax_add_to_cart_button btn btn-default']/span"));
            //IWebElement productCell = products[index];
            //actions.MoveToElement(productCell);
            //productCell.Click();

            ////div[@class='button-container']/a[@class='btn btn-default button button-medium']/span

            //IWebElement checkbox = webDriver.FindElement(By.Id("cgv"));
            //checkbox.Click();
            



            IWebElement subjectHeading = webDriver.FindElement(By.Id("id_contact"));
            SelectElement subjectHeadingCombobox = new SelectElement(subjectHeading);

            switch (option)
            {
                case Options.ByText:
                    subjectHeadingCombobox.SelectByText(value);
                    break;
                case Options.ByIndex:
                    subjectHeadingCombobox.SelectByIndex(int.Parse(value));
                    break;
                case Options.ByValue:
                    subjectHeadingCombobox.SelectByValue(value);
                    break;
            }            
        }

        public void SetEmail(string email)
        {
            IWebElement emailInput = webDriver.FindElement(By.Id("email"));
            emailInput.SendKeys(email);
        }

        public void SetOrderReference(string orderReference)
        {
            IWebElement orderReferenceInput = webDriver.FindElement(By.Id("id_order"));
            orderReferenceInput.SendKeys(orderReference);
        }

        public void SetAttachFile(string filePath)
        {
            IWebElement attachFileInput = webDriver.FindElement(By.Id("fileUpload"));
            IWebElement attachFileNameText = webDriver.FindElement(By.XPath("//span[@class='filename']"));
            wait.Until(ExpectedConditions.TextToBePresentInElement(attachFileNameText, "No file selected"));
            attachFileInput.SendKeys(filePath);
        }

        public void SetMessage(string message)
        {
            IWebElement messageInput = webDriver.FindElement(By.Id("message"));
            messageInput.SendKeys(message);
        }

        public void ClickSend()
        {
            IWebElement sendButton = webDriver.FindElement(By.Id("submitMessage"));
            sendButton.Click();
        }

        public string GetConfirmationLabel()
        {
            IWebElement confirmationLabel = webDriver.FindElement(By.XPath("//div[@id='center_column']/p"));
            string confirmationMessage = confirmationLabel.Text;
            return confirmationMessage;
        }        

        public string GetErrorLabel()
        {
            IWebElement errorLabel = webDriver.FindElement(By.XPath("//div[@class='alert alert-danger']/ol/li"));
            string errorMessage = errorLabel.Text;
            return errorMessage;
        }

        public void FillContactUsForm(Options option, string value, string email, string orderReference,
            string filePath, string message)            
        {
            SelectSubjectHeading(option, value);
            SetEmail(email);
            SetOrderReference(orderReference);
            SetAttachFile(filePath);
            SetMessage(message);
            ClickSend();
        }
    }
}
