namespace SeleniumTests.Pages.ResizablePage
{
    using OpenQA.Selenium;

    public partial class ResizablePage
    {
        //Resizable Side Tabs
        public IWebElement Constrain => this.Driver.FindElement(By.Id("ui-id-3"));

        //Resizable Objects

        public IWebElement ResizableObject => this.Driver.FindElement(By.Id("resizable"));

        public IWebElement HandleObject => this.Driver.FindElement(By.XPath(@"//*[@id=""resizable""]/div[3]"));

        public IWebElement ResizableObjectMovable => this.Driver.FindElement(By.Id("resizableconstrain"));

        public IWebElement HandleMovableObject => this.Driver.FindElement(By.XPath(@"//*[@id=""resizableconstrain""]/div[3]"));

        public IWebElement ResizableObjectFixed => this.Driver.FindElement(By.Id("container1"));

    }
}
