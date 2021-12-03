using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;
using System.Collections.Generic;
using XE_Task2.Pages;
using XE_Task2.Settings;
using XE_Task2.Steps;

namespace XE_Task2.Tests
{
    public class Tests : DriverTestsBase
    {
        private LoginPageSteps loginPageSteps;
        private HomePageSteps homePageSteps;

        [SetUp]
        public void Setup()
        {
            loginPageSteps = new LoginPageSteps(new LoginPage(Driver));
            homePageSteps = new HomePageSteps(new HomePage(Driver));
        }

        [TearDown]
        public void Teardown()
        {
            DriverCleanup();
        }

        [Test]
        public void EmailAndPasswordFieldsValidation()
        {
            // Load Homepage
            loginPageSteps.NavigateToPage();

            // Assert that something expected has happened
            using (new AssertionScope())
            {
                loginPageSteps.ValidateLoginInputsAreVisible().Should().BeTrue();
            }
        }

        [Test]
        public void ValidCredentialsLogin()
        {
            // Act
            loginPageSteps.NavigateToPage();
            loginPageSteps.EnterCredentialsAndLogin(TestSettings.ValidEmail, TestSettings.Password);

            // Asert
            using (new AssertionScope())
            {
                homePageSteps.ValidateSuccessMessage("Welcome to Codility").Should().BeTrue();
            }
        }

        [Test]
        public void InvalidCredentialsLogin()
        {
            // Arrange
            List<string> expectedErrorMessages = new List<string>()
            {
                "You shall not pass! Arr!"
            };

            // Act
            loginPageSteps.NavigateToPage();
            loginPageSteps.EnterCredentialsAndLogin(TestSettings.UnknownEmail, TestSettings.Password);

            // Assert
            using (new AssertionScope())
            {
                loginPageSteps.ValidateErrorMessages().Should().BeEquivalentTo(expectedErrorMessages);
            }
        }

        [Test]
        public void EmailFieldValidation()
        {
            // Arrange
            List<string> expectedErrorMessages = new List<string>()
            {
                "Enter a valid email"
            };

            // Act
            loginPageSteps.NavigateToPage();
            loginPageSteps.EnterCredentialsAndLogin(TestSettings.InvalidEmail, TestSettings.Password);

            // Assert
            using (new AssertionScope())
            {
                loginPageSteps.ValidateErrorMessages().Should().BeEquivalentTo(expectedErrorMessages);
            }
        }

        [Test]
        public void EmptyCredentialValidation()
        {
            // Arrange
            List<string> expectedErrorMessages = new List<string>()
            {
                "Email is required",
                "Password is required"
            };

            // Act
            loginPageSteps.NavigateToPage();
            loginPageSteps.EnterCredentialsAndLogin("", "");

            // Assert
            using (new AssertionScope())
            {
                loginPageSteps.ValidateErrorMessages().Should().BeEquivalentTo(expectedErrorMessages);
            }
        }
    }
}
