using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace XE_Task2.Pages
{
    public class HomePage : PageBase
    {
        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public override string PageTabTitle =>
            "ARR";

        public override string Url =>
            "https://codility-frontend-prod.s3.amazonaws.com/media/task_static/qa_login_page/9a83bda125cd7398f9f482a3d6d45ea4/static/attachments/reference_page.html";


        private IWebElement WelcomeMessage() =>
            WaitForAndReturnElement(".success"); // current class is actually "message success" which is quite fragile, would look to change this and add a Id

        public bool ValidateWelcomeMessage(string welcomeMessage)
        {
            var element = WelcomeMessage();

            if (element.Displayed == true && element.Text == welcomeMessage)
            {
                return true;
            }

            return false;
        }
    }
}