namespace CreditCards.EndToEndTests.Pages.ApplicationCompletePage
{
	using OpenQA.Selenium;

	public partial class ApplicationCompletePage
    {
        public IWebElement Name => this.Driver.FindElement(By.Id("fullName"));

        public  IWebElement Decision => this.Driver.FindElement(By.Id("decision"));
    }
}