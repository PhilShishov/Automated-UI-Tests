namespace CreditCards.EndToEndTests.Pages.ApplicationPage
{
	using OpenQA.Selenium;

	public partial class ApplicationPage
    {
        public IWebElement FirstName => this.Driver.FindElement(By.Name("FirstName"));

        public IWebElement LastName => this.Driver.FindElement(By.Name("LastName"));
		
        public IWebElement FrequentFlyerNumber => this.Driver.FindElement(By.Id("FrequentFlyerNumber"));

	    public IWebElement Age => this.Driver.FindElement(By.Id("Age"));

	    public IWebElement GrossAnnualIncome => this.Driver.FindElement(By.Id("GrossAnnualIncome"));

	    public IWebElement ApplyButton => this.Driver.FindElement(By.Id("submitApplication"));

        private IWebElement FirstError => this.Driver.FindElement(By.CssSelector(".validation-summary-errors ul > li"));

        public string FirstErrorMessage => FirstError.Text;       
    }
}

