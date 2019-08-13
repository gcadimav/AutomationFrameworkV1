using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using PageObjectLibrary.Base;

namespace PageObjectLibrary.PageObjects.AutomationPractice.ContactUs
{
    public class ContactUsPage: BasePage
    {

        #region web controls

        private IWebElement subjectHeading => GetDriver().FindElement(By.Id("id_contact"));
        private IWebElement emailInput => GetDriver().FindElement(By.Id("email"));
        private IWebElement orderReferenceInput => GetDriver().FindElement(By.Id("id_order"));
        private IWebElement attachFileInput => GetDriver().FindElement(By.Id("fileUpload"));
        private IWebElement attachFileNameText => GetDriver().FindElement(By.XPath("//span[@class='filename']"));
        private IWebElement messageInput => GetDriver().FindElement(By.Id("message"));
        private IWebElement sendButton => GetDriver().FindElement(By.Id("submitMessage"));
        private IWebElement confirmationLabel => GetDriver().FindElement(By.XPath("//div[@id='center_column']/p"));
        private IWebElement errorLabel => GetDriver().FindElement(By.XPath("//div[@class='alert alert-danger']/ol/li"));

        #endregion

        public enum Options
        {
            ByText,
            ByIndex,
            ByValue
        }

        public void SelectSubjectHeading(Options option, string value)
        { 
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
            emailInput.SendKeys(email);
        }

        public void SetOrderReference(string orderReference)
        {
            orderReferenceInput.SendKeys(orderReference);
        }

        public void SetAttachFile(string filePath)
        {
            wait.Until(ExpectedConditions.TextToBePresentInElement(attachFileNameText, "No file selected"));
            attachFileInput.SendKeys(filePath);
        }
        
        public void SetMessage(string message)
        {            
            messageInput.SendKeys(message);
        }

        public void ClickSend()
        {            
            sendButton.Click();
        }

        public string GetConfirmationLabel()
        {
            return confirmationLabel.Text;
        }        

        public string GetErrorLabel()
        {            
            return errorLabel.Text;
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
