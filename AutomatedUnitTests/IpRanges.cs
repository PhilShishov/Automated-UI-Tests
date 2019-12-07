namespace AutomatedUnitTests
{
    using System.IO;
    using System.Threading;
    using System.Reflection;

    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    using AutomatedUnitTests.Pages.IpHomePage;

    [TestFixture]
    public class IpRanges
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
        * IpRanges Test
        * 
        *************************************************************************************************/

        [Test]
        public void ExtractAllIPsInTheWorld()
        {
            var ipHomePage = new IpHomePage(_driver);
            ipHomePage.NavigateTo("http://services.ce3c.be/ciprg/");
            var names = ipHomePage.GetNames();
            foreach (var name in names)
            {
                ipHomePage.SearchBox.Clear();
                ipHomePage.SearchBox.SendKeys(name);
                ipHomePage.RadioButton.Click();
                ipHomePage.Generate.Click();
                Thread.Sleep(1000);

                File.WriteAllText(Path.GetFullPath($@"../../../CountryIp/{name}.txt"), ipHomePage.Ips);

                Thread.Sleep(1000);

                ipHomePage.NavigateTo("http://services.ce3c.be/ciprg/");
            }
        }
    }
}
