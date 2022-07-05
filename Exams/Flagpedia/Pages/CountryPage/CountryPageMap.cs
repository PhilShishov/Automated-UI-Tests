namespace Flagpedia.Pages.CountryPage
{
    using System.Linq;

    using OpenQA.Selenium;

    public partial class CountryPage
    {
        public IWebElement Name => Wait.Until(d => d
        .FindElement(By.XPath(@"//*[@id=""content""]/table/tbody/tr[3]/td")));

        public IWebElement Capital => Wait.Until(d => d
        .FindElement(By.XPath(@"//*[@id=""content""]/table/tbody/tr[4]/td")));

        public IWebElement Content => Wait.Until(d => d
        .FindElement(By.Id("content")));

        public IWebElement Code => Content
            .FindElements(By.TagName("em")).ToList().Last();
    }
}