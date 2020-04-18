
namespace SeleniumTests.Pages.DraggablePage
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using System;

    public partial class DraggablePage : BasePage
    {
        public DraggablePage(IWebDriver driver)
            : base(driver)
        {
        }

        //public string URL = this.URL + "draggable";        

        public void DragCursor()
        {
            Actions action = new Actions(this.Driver);
            action.MoveToElement(DragObjectCursor)
                .ClickAndHold(DragObjectCursor)
                .MoveByOffset(60, 90)
                .Release()                
                .Perform();
        }
    }
}
