
namespace AutomatedUnitTests
{
    using AutomatedUnitTests.Pages.NetCorePage;
    using FluentAssertions;
    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class NetCore
    {
        private IWebDriver _driver;
        private NetCorePage _netCorePage;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _netCorePage = new NetCorePage(_driver);
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
        public void VerifyLinkName_EqualsAndScrollsTo_TitleName()
        {
            _netCorePage.NavigateTo("https://docs.microsoft.com/en-us/dotnet/csharp/");
            _netCorePage.NetCoreGuideLink.Click();
            _netCorePage.DockerArticleLink.Click();
            _netCorePage.IntroductionArticleLink.Click();
            
            for (int i = 0; i < _netCorePage.Links.Count; i++)
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
                var valueBefore = js.ExecuteScript("return window.pageYOffset;");

                string linkTitle = _netCorePage.Links[i].Text;
                _netCorePage.Links[i].Click();

                string expected = _netCorePage.Titles[i].Text;
                var valueAfter = js.ExecuteScript("return window.pageYOffset;");

                expected.Should().Be(linkTitle);
                valueBefore.Should().NotBe(valueAfter);

                _netCorePage.Back();
            }
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void VerifyAllArticles_NameEqualsTitleName(int elementNum)
        {
            _netCorePage.NavigateTo("https://docs.microsoft.com/en-us/dotnet/csharp/");
            _netCorePage.NetCoreGuideLink.Click();
            _netCorePage.DockerArticleLink.Click();

            _netCorePage.ListArticles[elementNum].Click();

            for (int i = 0; i < _netCorePage.Links.Count; i++)
            {
                string linkTitle = _netCorePage.Links[i].Text;
                _netCorePage.Links[i].Click();

                string expected = _netCorePage.Titles[i].Text;
                expected.Should().Be(linkTitle);

                _netCorePage.Back();
            }
        }
    }
}

