using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace XE_Task2.Tests
{
    public class DriverTestsBase
    {
        public IWebDriver Driver;

        [SetUp]
        public void BaseSetup()
        {
            // Setup and Create driver
            if (Driver == null)
            {
                Driver = new ChromeDriver();
            }
        }

        public void DriverCleanup()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }
    }
}