namespace Exam_Flagpedia
{
    using System.IO;
    using System.Reflection;

    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    using Exam_Flagpedia.Pages.IndexPage;
    using Exam_Flagpedia.Pages.CountryPage;
    using System.Threading;

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
                Thread.Sleep(1000);

                string url = "http://flagpedia.net/" + element;
                countryPage.NavigateTo(url);
                ((IJavaScriptExecutor)_driver)
                    .ExecuteScript("window.scrollTo(0, document.body.scrollHeight / 4)");

                var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
                screenshot.SaveAsFile(Path.GetFullPath
                    (@"../../../Screenshots/Flags/") + CountryPage.BuildName(countryPage) + ".png", 
                    ScreenshotImageFormat.Png);
            }
        }
    }
}
