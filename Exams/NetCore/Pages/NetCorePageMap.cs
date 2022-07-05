namespace Exam_NetCore.Pages
{
    using System.Linq;
    using System.Collections.Generic;

    using OpenQA.Selenium;

    public partial class NetCorePage
    {
        public IWebElement NetCoreGuideLink => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""filterResults""]/ul/li[3]/a")));

        public IWebElement DockerArticleLink => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""filterResults""]/ul/li[3]/ul/li[12]/a")));

        public IWebElement IntroductionArticleLink => Wait.Until(d => d.FindElement(By.XPath(@"//*[@id=""filterResults""]/ul/li[3]/ul/li[12]/ul/li[1]/a")));


        public IWebElement InThisNavContainer => Wait.Until(d => d.FindElement(By.XPath(@"//div[@id='page-actions-content']")));
        
        public List<IWebElement> Titles => this.Driver
               .FindElements(By.TagName("h2")).ToList();

        public List<IWebElement> Links => InThisNavContainer        
                .FindElements(By.TagName("a")).ToList();

        public List<IWebElement> ListArticles => this.Driver.FindElement(By.XPath("(//UL[@role='tree'])[19]"))
                .FindElements(By.TagName("a")).ToList();
    }
}