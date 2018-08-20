namespace AutomatedUnitTests
{
    using AutomatedUnitTests.Pages.CountryPage;
    using AutomatedUnitTests.Pages.IndexPage;
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class Flagpedia
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        /*************************************************************************************************
        *
        * Flagpedia Test
        * 
        *************************************************************************************************/

        [Test]
        public void ExtractAllFlagsInTheWorld()
        {
            var indexPage = new IndexPage(_driver);
            var countryPage = new CountryPage(_driver);
            indexPage.NavigateTo("http://flagpedia.net/index");

            var countryNames = indexPage.GetNames();
            foreach (var element in countryNames)
            {
                string url = "http://flagpedia.net/" + element;
                countryPage.NavigateTo(url);
                ((IJavaScriptExecutor)_driver).ExecuteScript("window.scrollTo(0, document.body.scrollHeight - 150)");

                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile(Path.GetFullPath(@"../../../Screenshots/Flags/") + countryPage.BuildName(countryPage) + ".png", ScreenshotImageFormat.Png);
            }
        }
    }
}
