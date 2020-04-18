namespace SeleniumTests.Pages.DroppablePage
{
    using OpenQA.Selenium;

    public partial class DroppablePage
    {
        //Droppable Side Tabs
        public IWebElement Accept => this.Driver.FindElement(By.Id("ui-id-2"));

        public IWebElement Revert => this.Driver.FindElement(By.Id("ui-id-4"));

        //Droppable Objects

        public IWebElement DropObject => this.Driver.FindElement(By.Id("draggableview"));

        public IWebElement DropObjectTarget => this.Driver.FindElement(By.Id("droppableview"));

        public IWebElement DropTargetAfterAction => this.Driver.FindElement(By.CssSelector(".ui-state-highlight, .ui-widget-content .ui-state-highlight, .ui-widget-header .ui-state-highlight"));

        public IWebElement DropObjectNonValid => this.Driver.FindElement(By.Id("draggable-nonvalid"));

        public IWebElement DropObjectAccept => this.Driver.FindElement(By.Id("draggableaccept"));

        public IWebElement DropObjectValidTarget => this.Driver.FindElement(By.Id("droppableaccept"));

        // Droppable Objects Revert

        public IWebElement SourceStart => this.Driver.FindElement(By.Id("draggablerevert"));

        public IWebElement Target => this.Driver.FindElement(By.Id("droppablerevert"));

        public IWebElement FullTarget => this.Driver.FindElement(By.Id("droppablerevert"));

        public IWebElement SourceEnd => this.Driver.FindElement(By.Id("draggablerevert"));
    }
}
