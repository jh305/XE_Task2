using System;
using System.Collections.Generic;
using System.Text;
using XE_Task2.Pages;

namespace XE_Task2.Steps
{
    public class HomePageSteps
    {
        private HomePage homepage;
        public HomePageSteps(HomePage homepage)
        {
            this.homepage = homepage;
        }

        public bool ValidateSuccessMessage(string expectedMessage) =>
            homepage.ValidateWelcomeMessage(expectedMessage);
    }
}