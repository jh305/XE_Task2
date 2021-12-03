using OpenQA.Selenium;
using System.Collections.Generic;
using XE_Task2.Settings;

namespace XE_Task2.Pages
{
    public class LoginPage : PageBase
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public override string Url =>
            TestSettings.BaseUrl;

        public override string PageTabTitle =>
            "ARR";

        private IWebElement EmailInputElement =>
            WaitForAndReturnElement("#email-input");

        private IWebElement PasswordInputElement =>
            WaitForAndReturnElement("#password-input");

        private IWebElement LoginButtonElement =>
            WaitForAndReturnElement("#login-button");

        private IWebElement ErrorMessages() =>
            WaitForAndReturnElement("#messages");

        public void Login(string email, string password)
        {
            ClearAndEnterInput(EmailInputElement, email);

            ClearAndEnterInput(PasswordInputElement, password);

            LoginButtonElement.Click();
        }

        public List<string> ValidateErrorMessages()
        {
            List<string> errorMessages = new List<string>();

            IReadOnlyCollection<IWebElement> webElements = ErrorMessages().FindElements(By.ClassName("error"));

            foreach (IWebElement element in webElements)
            {
                errorMessages.Add(element.Text);
            }

            return errorMessages;
        }

        public bool CheckLoginInputsAreVisible()
        {
            if (EmailInputElement.Displayed && EmailInputElement.Enabled && PasswordInputElement.Displayed && PasswordInputElement.Enabled)
            {
                return true;
            }

            return false;
        }
    }
}