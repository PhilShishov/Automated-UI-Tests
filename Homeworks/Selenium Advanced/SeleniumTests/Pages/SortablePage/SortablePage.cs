namespace SeleniumTests.Pages.SortablePage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public partial class SortablePage : BasePage
    {
        public SortablePage(IWebDriver driver)
            : base(driver)
        {
        }

        public void SortLists()
        {
            Actions action = new Actions(this.Driver);
                action.DragAndDrop(SortableListOneFifth, SortableListTwoForth)
                    .DragAndDrop(SortableListOneSecond, SortableListTwoSecond)
                    .Perform();            
        }
    }
}
