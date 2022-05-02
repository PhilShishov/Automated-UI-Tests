namespace CreditCards.EndToEndTests.Pages.ApplicationCompletePage
{
	using OpenQA.Selenium;

	public partial class ApplicationCompletePage
    {
        public IWebDriver Driver { get; }

        public ApplicationCompletePage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}