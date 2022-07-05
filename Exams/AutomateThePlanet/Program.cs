﻿namespace AutomateThePlanet
{
    using System.IO;
    using System.Reflection;
    using System.Threading;

    using FluentAssertions;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    using AutomateThePlanet.Pages;

    [TestFixture]
    public class Program
    {
        private IWebDriver _driver;
        private AutomateThePlanetPage _autoPage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _autoPage = new AutomateThePlanetPage(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile(@"..\..\..\Screenshots\FailedTests\" + TestContext.CurrentContext.Test.Name + ".png", ScreenshotImageFormat.Png);
            }
            _driver.Quit();
        }

        [Test]
        public void VerifyLink_Equals_TitleAndHeaderOfTitle()
        {
            _autoPage.NavigateTo("https://www.automatetheplanet.com/");
            _autoPage.BlogLink.Click();
            _autoPage.RandomArticleLink.Click();
            _autoPage.SubscribeCloseButton.Click();
            _autoPage.CookiesAcceptButton.Click();
            _autoPage.ScrolltoQuickNav();

            for (int i = 0; i < _autoPage.Links.Count; i++)
            {
                string linkTitle = _autoPage.Links[i].Text;
                _autoPage.Links[i].Click();

                string expected = _autoPage.Titles[i].Text;
                expected.Should().Be(linkTitle);
                _autoPage.Titles[i].TagName.Should().BeOneOf("h2", "h3");

                _autoPage.ScrolltoQuickNav();
            }
        }
    }
}