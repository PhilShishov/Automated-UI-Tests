namespace Exam_AutomateThePlanet.Pages
{
    using System;
    using System.Threading;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;

    public class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }

        public WebDriverWait Wait => new WebDriverWait(this.Driver, TimeSpan.FromSeconds(5));

        public void NavigateTo(string url)
        {
            this.Driver.Manage().Window.Maximize();

            if (url.Contains(" ") || url.Contains("'"))
            {
                url = url.Replace(" ", "-");
                url = url.Replace("'", "-");
            }

            this.Driver.Url = url;
        }

        public void Back()
        {
            Thread.Sleep(1000);
            Driver.Navigate().Back();
        }
    }
}