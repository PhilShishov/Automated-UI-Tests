namespace Flagpedia.Pages.IndexPage
{
    using System.Linq;
    using System.Collections.Generic;

    using OpenQA.Selenium;

    public partial class IndexPage
    {
        public List<IWebElement> CountryNames => 
            Driver.FindElement(By.ClassName("flag-grid"))
            .FindElements(By.TagName("li")).ToList();
    }
}