namespace Exam_AutomateThePlanet.Pages
{
    using System.Linq;
    using System.Collections.Generic;

    using OpenQA.Selenium;

    public partial class AutomateThePlanetPage
    {
        public IWebElement BlogLink =>
            Wait.Until(d => d.FindElement(By
                .XPath(@"//*[@id=""menu-item-6""]/a")));

        public IWebElement RandomArticleLink =>
            Wait.Until(d => d.FindElement(By
                .XPath(@"//*[@id=""post-5392""]/div[1]/a")));

        public IWebElement SubscribeCloseButton =>
            Wait.Until(d => d.FindElement(By
                .XPath(@"/html/body/div[10]/div/div/div/div/div/div[1]/div")));

        public IWebElement CookiesAcceptButton =>
            Wait.Until(d => d.FindElement(By
                .Id("cookie_action_close_header")));

        public IWebElement QuickNavEl =>
            Wait.Until(d => d.FindElement(By
                .XPath("//span[@class=\'tve_ct_title\'][contains(.,\'Quick Navigation\')]")));

        public List<IWebElement> Titles =>
            Wait.Until(d => d.FindElements(By.XPath(@"//*[contains(@id, 'tab-con')]")).ToList());

        public List<IWebElement> Links =>
             Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""tve_editor""]/div[2]/div"))
                .FindElements(By.TagName("a")).ToList());
    }
}

