
namespace SeleniumTests
{
    using System.IO;
    using System.Reflection;
    using System.Threading;

    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [TestFixture]
    public class GoogleSearch
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            ClearBrowserCache();
            _driver.Url = "http://duckduckgo.com";
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }

        [Test]
        public void Confirm_NameOfTitleOf_SearchedItem()
        {
            IWebElement search = _driver.FindElement(By.Name("q"));
            search.SendKeys("Selenium C#");
            search.SendKeys(Keys.Enter);

            _driver.FindElement(By.XPath("//*[@id=\"r1-0\"]/div/h2")).Click();

            StringAssert.IsMatch("Selenium with C# Tutorial", _driver.Title);
        }

        private void ClearBrowserCache()
        {
            _driver.Manage().Cookies.DeleteAllCookies(); //delete all cookies
            Thread.Sleep(3000); //wait 3 seconds to clear cookies.
        }
    }
}
