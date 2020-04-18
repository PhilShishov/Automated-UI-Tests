
namespace SeleniumTests.Pages.SelectablePage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;

    public partial class SelectablePage : BasePage
    {
        public SelectablePage(IWebDriver driver)
            : base(driver)
        {
        }
        public void SelectMultipleSerialize()
        {          
            Actions action = new Actions(this.Driver);
            action.MoveToElement(SelectableObjectSerializeSecond)
                .ClickAndHold()
                .Release(SelectableObjectSerializeFifth)
                .Perform();
        }
    }
}
