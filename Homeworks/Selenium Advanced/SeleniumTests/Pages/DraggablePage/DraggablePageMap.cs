
namespace SeleniumTests.Pages.DraggablePage
{
    using OpenQA.Selenium;

    public partial class DraggablePage
    {
        //Draggable Side Tabs
        public IWebElement ConstrainMovement => Wait.Until(d => d.FindElement(By.Id("ui-id-2")));

        public IWebElement CursorStyle => Wait.Until(d => d.FindElement(By.Id("ui-id-3")));

        //Draggable Objects
        public IWebElement DragObject => Wait.Until(d => d.FindElement(By.Id("draggable")));

        public IWebElement DragObjectVertical => Wait.Until(d => d.FindElement(By.Id("draggabl")));

        public IWebElement DragObjectCursor => Wait.Until(d => d.FindElement(By.Id("drag")));
    }
}
