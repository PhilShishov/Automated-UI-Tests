namespace AutomatedUnitTests.Pages.IpHomePage
{
    using System.Linq;
    using System.Collections.Generic;

    using OpenQA.Selenium;

    public partial class IpHomePage
    {
        public List<IWebElement> Names => Driver
            .FindElement(By.XPath("/html/body/table/tbody"))
            .FindElements(By.TagName("a")).ToList();

        public IWebElement SearchBox => Wait.Until(d => d.FindElement(By.Name("countrys")));

        public IWebElement RadioButton => Wait.Until(d => d.FindElement(By.XPath("/html/body/form/input[3]")));

        public IWebElement Generate => Wait.Until(d => d.FindElement(By.XPath("/html/body/form/input[5]")));

        public string Ips => Wait.Until(d => d.FindElement(By.XPath("/html/body/pre"))).Text;
    }
}