namespace AutomatedUnitTests.Pages.CountryPage
{
    using System.Linq;

    using OpenQA.Selenium;

    public partial class CountryPage
    {
        public IWebElement Name => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""content""]/dl[1]/dd[2]")));

        public IWebElement Capital => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""content""]/dl[1]/dd[3]")));

        public IWebElement Content => Wait.Until(d => d.FindElement(By.Id("content")));

        ////*[@id="content"]/dl[1]/dd[9]/em
        public IWebElement Code => Content.FindElements(By.TagName("em")).ToList().Last();
    }
}