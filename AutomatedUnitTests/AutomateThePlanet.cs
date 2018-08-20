namespace AutomatedUnitTests
{
    using AutomatedUnitTests.Pages.AutomateThePlanet;
    using FluentAssertions;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Reflection;
    using System.Threading;

    [TestFixture]
    public class AutomateThePlanet
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
            _autoPage.ScrolltoQuickNav();

            for (int i = 0; i < _autoPage.Links.Count; i++)
            {
                string linkTitle = _autoPage.Links[i].Text;
                _autoPage.Links[i].Click();

                string expected = _autoPage.Titles[i].Text;
                expected.Should().Be(linkTitle);
                _autoPage.Titles[i].TagName.Should().BeOneOf("h2", "h3");

                _autoPage.Back();
            }

            //foreach (var element in _autoPage.Links)
            //{
            //    element.Click();
            //    var linkName = element.Text;
            //    var el = _driver.
            //        FindElement(By.XPath($"//h2[contains(.,\'{linkName}\')]|//h3[contains(.,\'{linkName}\')]"));
            //    linkName.Should().Be(el.Text);
            //    el.TagName.Should().BeOneOf("h2", "h3");

            //    _autoPage.Back();
            //}
        }        
    }
}