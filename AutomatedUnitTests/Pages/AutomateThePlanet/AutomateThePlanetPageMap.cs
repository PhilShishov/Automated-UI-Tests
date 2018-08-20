namespace AutomatedUnitTests.Pages.AutomateThePlanet
{
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;

    public partial class AutomateThePlanetPage
    {
        public IWebElement BlogLink => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""menu-item-6""]/a")));

        public IWebElement RandomArticleLink => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""post-7811""]/div[1]/a/span[2]")));

        public IWebElement QuickNavEl =>
            Driver.FindElement(By.XPath("//span[@class=\'tve_ct_title\'][contains(.,\'Quick Navigation\')]"));

        public List<IWebElement> Titles => this.Driver
               .FindElements(By.XPath(@"//*[contains(@id, 'tab-con')]")).ToList();

        public List<IWebElement> Links => this.Driver
                 .FindElement(By.XPath(@"//*[@id=""tve_editor""]/div[2]/div"))
                .FindElements(By.TagName("a")).ToList();

        ////DIV[@class='tve_contents_table tve_clearfix']
    }
}

