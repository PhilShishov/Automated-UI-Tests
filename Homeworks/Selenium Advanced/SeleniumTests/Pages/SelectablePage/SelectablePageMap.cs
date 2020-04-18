namespace SeleniumTests.Pages.SelectablePage
{
    using OpenQA.Selenium;

    public partial class SelectablePage
    {
        //Selectable Side Tabs
        public IWebElement Serialize => this.Driver.FindElement(By.Id("ui-id-3"));

        //Selectable Objects

        public IWebElement SelectableObjectFirst => this.Driver.FindElement(By.XPath(@"//*[@id=""selectable""]/li[1]"));
        public IWebElement SelectableObjectSecond => this.Driver.FindElement(By.XPath(@"//*[@id=""selectable""]/li[2]"));
        public IWebElement SelectableObjectThird => this.Driver.FindElement(By.XPath(@"//*[@id=""selectable""]/li[3]"));
        public IWebElement SelectableObjectFourth => this.Driver.FindElement(By.XPath(@"//*[@id=""selectable""]/li[4]"));
        public IWebElement SelectableObjectFifth => this.Driver.FindElement(By.XPath(@"//*[@id=""selectable""]/li[5]"));
        public IWebElement SelectableObjectSixth => this.Driver.FindElement(By.XPath(@"//*[@id=""selectable""]/li[6]"));
        public IWebElement SelectableObjectSeventh => this.Driver.FindElement(By.XPath(@"//*[@id=""selectable""]/li[7]"));

        //Selectable Objects Serialize

        public IWebElement HeaderSelectableObjectSerialize => this.Driver.FindElement(By.Id("feedback"));

        public IWebElement SelectableObjectSerializeFirst => this.Driver.FindElement(By.XPath(@"//*[@id=""selectable - serialize""]/li[1]"));
        public IWebElement SelectableObjectSerializeSecond => this.Driver.FindElement(By.XPath(@"//*[@id=""selectable-serialize""]/li[2]"));
        public IWebElement SelectableObjectSerializeThird => this.Driver.FindElement(By.XPath(@"//*[@id=""selectable-serialize""]/li[3]"));
        public IWebElement SelectableObjectSerializeFourth => this.Driver.FindElement(By.XPath(@"//*[@id=""selectable-serialize""]/li[4]"));
        public IWebElement SelectableObjectSerializeFifth => this.Driver.FindElement(By.XPath(@"//*[@id=""selectable-serialize""]/li[5]"));
        public IWebElement SelectableObjectSerializeSixth => this.Driver.FindElement(By.XPath(@"//*[@id=""selectable-serialize""]/li[6]"));
        public IWebElement SelectableObjectSerializeSeventh => this.Driver.FindElement(By.XPath(@"//*[@id=""selectable-serialize""]/li[7]"));
    }
}
