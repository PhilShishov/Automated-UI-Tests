namespace AutomatedUnitTests.Pages.CountryPage
{
    using OpenQA.Selenium;

    public partial class CountryPage : BasePage
    {
        public CountryPage(IWebDriver driver) :base(driver)
        {

        }
        public string BuildName(CountryPage page)
        {
            return $"{page.Name.Text}-{page.Capital.Text}-{page.Code.Text}";
        }
    }
}