namespace SeleniumTests.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Support.UI;
    using System;

    public abstract class BasePage
    {
        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public IWebDriver Driver { get; private set; }

        public WebDriverWait Wait => new WebDriverWait(this.Driver, TimeSpan.FromSeconds(5));        

        public void NavigateTo(string url)
        {
            this.Driver.Url = url;
            this.Driver.Manage().Window.Maximize();
        }

        public void DragAndDropToOffset(IWebElement element, int x, int y)
        {
            Actions action = new Actions(this.Driver);
            action.DragAndDropToOffset(element, x, y)
                .Perform();
        }

        public void DragAndDrop(IWebElement elementDrag, IWebElement elementDrop)
        {
            Actions action = new Actions(this.Driver);
            action.DragAndDrop(elementDrag, elementDrop)
                .Perform();
        }

        public void Resize(IWebElement element, int x, int y)
        {
            Actions actions = new Actions(this.Driver);
            actions.ClickAndHold(element)
                .MoveByOffset(x, y)
                .Release()
                .Perform();
        }
    }
}