using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace XE_Task2.Pages
{
    public abstract class PageBase
    {
        private WebDriverWait Wait;

        public IWebDriver Driver { get; }

        public abstract string PageTabTitle { get; }

        public abstract string Url { get; }

        protected PageBase(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        }

        public void NavigateToPage()
        {
            Driver.Url = Url;
            WaitForPageToLoad();
        }

        /// <summary>
        /// Waits for and returns a webelement by searching and polling the page for the element
        /// for a certain amount of time (Currently set to 30 seconds in the constructor.)
        /// </summary>
        /// <param name="cssSelector">The CSS selector.</param>
        public IWebElement WaitForAndReturnElement(string cssSelector)
        {
            Wait.Message = $"Failed to wait for ReturnElements(By.CssSelector: {cssSelector})) to return at least ";
            return Wait.Until(d => ReturnElement(cssSelector));
        }

        public IWebElement ReturnElement(string cssSelector) =>
            Driver.FindElement(By.CssSelector(cssSelector));

        /// <summary>
        /// Waits for the page to load by polling the Expected Page Url and Title.
        /// </summary>
        public void WaitForPageToLoad()
        {
            string baseMessage = $"Failed to Wait for page with title {PageTabTitle} and URL {Url} to load";
            Wait.Message = baseMessage;

            Wait.Until(Driver =>
            {
                Wait.Message = $"{baseMessage}; Current Title: {Driver.Title}; Url: {Driver.Url}";
                return Driver.Url.StartsWith(Url) && Driver.Title.Equals(PageTabTitle);
            });
        }

        /// <summary>
        /// Clear an input field and then input a new value into it 
        /// To increase relaibility and reduce fragility, I have put a .Click and .Clear. This ensure that focus is on the 
        /// Input field and that it is cleared of any other text
        /// </summary>
        /// <param name="element"></param>
        /// <param name="input"></param>
        public void ClearAndEnterInput(IWebElement element, string input)
        {
            element.Click(); 
            element.Clear();

            element.SendKeys(input);           
        }
    }
}