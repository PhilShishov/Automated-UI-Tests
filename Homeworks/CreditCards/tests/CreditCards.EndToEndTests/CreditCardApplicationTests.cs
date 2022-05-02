namespace CreditCards.EndToEndTests
{
    using System;
    using System.IO;
    using System.Reflection;

    using CreditCards.EndToEndTests.Pages.ApplicationCompletePage;
    using CreditCards.EndToEndTests.Pages.ApplicationPage;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    using Xunit;

    public class CreditCardApplicationTests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly ApplicationPage _applicationPage;

        public CreditCardApplicationTests()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Navigate().GoToUrl("http://localhost:44108/");

            _applicationPage = new ApplicationPage(_driver);
            _applicationPage.NavigateTo();
        }

        [Fact]
        public void ShouldLoadApplicationPage_SmokeTest()
        {
            Assert.Equal("Credit Card Application - CreditCards", _applicationPage.Driver.Title);
        }

        [Fact]
        public void ShouldValidateApplicationDetails()
        {
            _applicationPage.FillForm("", "Smith", "012345-A", "20", "100000");

            Assert.Equal("Credit Card Application - CreditCards", _applicationPage.Driver.Title);
            Assert.Equal("Please provide a first name", _applicationPage.FirstErrorMessage);
        }

        [Fact]
        public void ShouldDeclineLowIncomes()
        {
            _applicationPage.FillForm("Sarah", "Smith", "012345-A", "35", "10000");

            ApplicationCompletePage applicationCompletePage =
                _applicationPage.SubmitApplication();

            Assert.Equal("Application Complete - CreditCards", applicationCompletePage.Driver.Title);
            Assert.Equal("AutoDeclined", applicationCompletePage.Decision.Text);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
