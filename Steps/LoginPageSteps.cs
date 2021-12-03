using System.Collections.Generic;
using XE_Task2.Pages;

namespace XE_Task2.Steps
{
    public class LoginPageSteps
    {
        private LoginPage loginPage;

        public LoginPageSteps(LoginPage loginPage)
        {
            this.loginPage = loginPage;
        }

        public void NavigateToPage() =>
            loginPage.NavigateToPage();

        public void EnterCredentialsAndLogin(string email, string password) =>
            loginPage.Login(email, password);

        public List<string> ValidateErrorMessages() =>
            loginPage.ValidateErrorMessages();

        public bool ValidateLoginInputsAreVisible() =>
            loginPage.CheckLoginInputsAreVisible();
    }
}