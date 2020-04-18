namespace AutomatedUnitTests.Pages.IndexPage
{
    using System.Linq;
    using System.Collections.Generic;

    using OpenQA.Selenium;

    public partial class IndexPage
    {
        public List<IWebElement> CountryNames => Driver.FindElements(By.ClassName("td-country")).ToList();
    }
}