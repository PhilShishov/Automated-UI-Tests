namespace SeleniumTests.Pages.DroppablePage
{
    using OpenQA.Selenium;

    public partial class DroppablePage : BasePage
    {
        public DroppablePage(IWebDriver driver)
            : base(driver)
        {
        }

        public void GoToUrl()
        {
            this.Driver.Url = "http://demoqa.com/droppable/";
        }
    }
}
