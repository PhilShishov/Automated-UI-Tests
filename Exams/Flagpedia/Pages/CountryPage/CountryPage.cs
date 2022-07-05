namespace Flagpedia.Pages.CountryPage
{
    using Exams.Common;

    using OpenQA.Selenium;

    public partial class CountryPage : BasePage
    {
        public CountryPage(IWebDriver driver) :base(driver)
        {

        }
        public static string BuildName(CountryPage page)
        {
            return $"{page.Name.Text}-{page.Capital.Text}-{page.Code.Text}";
        }
    }
}