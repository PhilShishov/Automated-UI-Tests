

namespace SeleniumTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.IO;
    using System.Reflection;

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
            _driver.FindElement(By.PartialLinkText("QA Automation - юни 2018")).Click();

            var header = _driver.FindElement(By.XPath("/html/body/div[3]/header/h1")).Text;

            Assert.AreEqual("QA Automation - юни 2018", header);         
        }
    }
}

