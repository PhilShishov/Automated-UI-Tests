namespace SeleniumTests.Pages.SortablePage
{
    using System.Collections.Generic;
    using System.Linq;

    using OpenQA.Selenium;

    public partial class SortablePage
    {
        //Sortable Side Tabs
        public IWebElement ConnectLists => Wait.Until(d => d.FindElement(By.Id("ui-id-2")));

        //Sortable Objects

        public IWebElement SortableFirst => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable""]/li[1]")));

        public IWebElement SortableSecond => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable""]/li[2]")));

        public IWebElement SortableThird => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable""]/li[3]")));

        public IWebElement SortableForth => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable""]/li[4]")));

        public IWebElement SortableFifth => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable""]/li[5]")));

        public IWebElement SortableSixth => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable""]/li[6]")));

        public IWebElement SortableSeventh => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable""]/li[7]")));

        //Sortable Objects Connect Lists

        public List<IWebElement> SortableListOne => Wait.Until(d => d.FindElements(By.XPath("//ul[@id='sortable1']/li")).ToList());

        public IWebElement SortableListOneFirst => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable1""]/li[1]")));

        public IWebElement SortableListOneSecond => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable1""]/li[2]")));

        public IWebElement SortableListOneThird => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable1""]/li[3]")));

        public IWebElement SortableListOneForth => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable1""]/li[4]")));

        public IWebElement SortableListOneFifth => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable1""]/li[5]")));


        public List<IWebElement> SortableListTwo => Wait.Until(d => d.FindElements(By.XPath("//ul[@id='sortable2']/li")).ToList());

        public IWebElement SortableListTwoFirst => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable2""]/li[1]")));

        public IWebElement SortableListTwoSecond => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable2""]/li[2]")));

        public IWebElement SortableListTwoThird => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable2""]/li[3]")));

        public IWebElement SortableListTwoForth => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable2""]/li[4]")));

        public IWebElement SortableListTwoFifth => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""sortable2""]/li[5]")));
    }
}
