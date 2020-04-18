namespace SeleniumTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using SeleniumTests.Pages;
    using System;
    using System.IO;
    using System.Reflection;
    using FluentAssertions;
    using SeleniumTests.Models;
    using SeleniumTests.Factories;
    using System.Collections.Generic;

    [TestFixture]
    public class DemoQA_Registration
    {
        private IWebDriver _driver;
        private RegistrationPage _regPage;
        private RegistrationUser _user;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _regPage = new RegistrationPage(_driver);
            _user = UserFactory.GenerateRegUser();
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void Confirm_NameOfTitleOf_SearchedPage()
        {            
            _driver.Url = "http://demoqa.com";
            _regPage.GoToUrl();

            _driver.Title.Should().Be("Registration | Demoqa"); 
        }

        [Test]
        public void Confirm_NameOfHeaderOf_SearchedPage()
        {
            _driver.Url = "http://demoqa.com";           

            _regPage.GoToUrl();

            _regPage.HeaderMessage.Displayed.Should().BeTrue();
            _regPage.HeaderMessage.Text.Should().Be("Registration");
        }

        [Test]
        [TestCase("Philip", "")]
        [TestCase("", "")]
        public void NotFilled_FirstLastNameField_Causes_ErrorMessageDisplay(string firstName, string lastName)
        {
            _regPage.GoToUrl();
            _user.FirstName = firstName;
            _user.LastName = lastName;

            _regPage.FillRegistrationForm(_user);

            Assert.IsTrue(_regPage.NameErrorMessage.Displayed);
            StringAssert.Contains("* This field is required", _regPage.NameErrorMessage.Text);
        }

        [Test]
        public void NotChosen_HobbyButtonsChoice_Causes_ErrorMessageDisplay()
        {
            _regPage.GoToUrl();
            _user.Hobbies = new List<bool>() { false, false, false };

            _regPage.FillRegistrationForm(_user);

            Assert.IsTrue(_regPage.HobbyErrorMessage.Displayed);
            StringAssert.Contains("* This field is required", _regPage.HobbyErrorMessage.Text);
        }

        [Test]
        public void NotCorrectlyFilled_UserNameField_Causes_ErrorMessageDisplay()
        {
            _regPage.GoToUrl();
            _user.UserName = "";

            _regPage.FillRegistrationForm(_user);


            Assert.IsTrue(_regPage.UsernameErrorMessage.Displayed);
            StringAssert.Contains("* This field is required", _regPage.UsernameErrorMessage.Text);
        }

        [Test]
        [TestCase("", "* This field is required")]
        [TestCase("359", "* Minimum 10 Digits starting with Country Code")]
        public void NotCorrectlyFilled_PhoneNumberField_Causes_ErrorMessageDisplay(string phoneNumber, string errorMessage)
        {
            _regPage.GoToUrl();
            _user.Phone = phoneNumber;

            _regPage.FillRegistrationForm(_user);

            _regPage.PhoneErrorMessage.Displayed.Should().BeTrue();
            _regPage.PhoneErrorMessage.Text.Should().Be(errorMessage);
        }

        [TestCase("123")]
        public void NotCorrectlyFilled_EmailField_Causes_ErrorMessageDisplay(string email)
        {
            _regPage.GoToUrl();
            _user.Email = email;

            _regPage.FillRegistrationForm(_user);
            
            _regPage.EmailErrorMessage.Displayed.Should().BeTrue();
            _regPage.EmailErrorMessage.Text.Should().Be("* Invalid email address");
        }

        [Test]
        [TestCase("", "* This field is required")]
        [TestCase("12345", "* Fields do not match")]
        public void NotCorrectlyFilled_PasswordField_Causes_ErrorMessageDisplay(string confirmPassword, string errorMessage)
        {
            _regPage.GoToUrl();
            _user.Password = "123456789";
            _user.ConfirmPassword = confirmPassword;

            _regPage.FillRegistrationForm(_user);

            _regPage.PasswordErrorMessage.Displayed.Should().BeTrue();
            _regPage.PasswordErrorMessage.Text.Should().Be(errorMessage);
        }
    }
}
