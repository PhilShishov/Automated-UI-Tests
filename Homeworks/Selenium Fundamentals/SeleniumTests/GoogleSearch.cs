
namespace SeleniumTests
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using System;
    using System.IO;
    using System.Reflection;

    [TestFixture]
    public class GoogleSearch
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            _driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));            
            _driver.Manage().Window.Maximize();
            _driver.Url = "http://google.com";
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
        }
        [Test]
        public void Confirm_NameOfTitleOf_SearchedItem()
        {           
            IWebElement search = _driver.FindElement(By.Id("lst-ib"));
            search.SendKeys("Selenium");
            search.SendKeys(Keys.Enter);

            _driver.FindElement(By.XPath("//*[@id=\"rso\"]/div[1]/div/div/div/div/h3/a")).Click();            

            StringAssert.IsMatch("Selenium - Web Browser Automation", _driver.Title);            
        }
    }
}
