
namespace SeleniumTests
{
    using System.IO;
    using System.Reflection;

    using NUnit.Framework;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [TestFixture]

    public class QA_Automation
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _driver.Manage().Window.Maximize();
            _driver.Url = "http://softuni.bg";
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
        [Test]
        public void ConfirmThat_HeadingTagHOne_Contains_SearchedTextMessage()
        {
            _driver.FindElement(By.XPath("//*[@id=\"header-nav\"]/div[1]/ul/li[2]/a")).Click();
            _driver.FindElement(By.PartialLinkText("C# Advanced")).Click();

            var header = _driver.FindElement(By.XPath("/html/body/div[2]/section[1]/section[1]/section[1]/section/h1")).Text;

            Assert.AreEqual("C# Advanced - май 2022", header);
        }
    }
}

