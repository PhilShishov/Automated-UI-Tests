namespace Exam_Flagpedia.Pages.IndexPage
{
    using System.Collections.Generic;

    using Exam_AutomateThePlanet.Pages;

    using OpenQA.Selenium;


    public partial class IndexPage : BasePage
    {
        public IndexPage(IWebDriver driver) : base(driver)
        {
        }

        public List<string> GetNames()
        {
            var list = new List<string>();
            foreach (var element in CountryNames)
            {
                list.Add(element.Text);
            }
            return list;
        }
    }
}