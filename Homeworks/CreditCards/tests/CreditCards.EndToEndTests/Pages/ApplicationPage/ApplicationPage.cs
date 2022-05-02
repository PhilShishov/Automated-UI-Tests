namespace CreditCards.EndToEndTests.Pages.ApplicationPage
{
    using System;

    using CreditCards.EndToEndTests.Pages.ApplicationCompletePage;

    using OpenQA.Selenium;

    public partial class ApplicationPage
    {
        public IWebDriver Driver { get; }

        private const string PagePath = "apply";

        public ApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public void NavigateTo()
        {
            var root = new Uri(Driver.Url).GetLeftPart(UriPartial.Authority);

            var url = $"{root}/{PagePath}";

            Driver.Navigate().GoToUrl(url);
        }

        public void FillForm(string firstName, string lastName, string ffn, string age, string income)
        {
            EnterName(firstName, lastName);
            EnterFrequentFlyerNumber(ffn);
            EnterAge(age);
            EnterGrossAnnualIncome(income);
            SubmitApplication();
        }

        private void EnterName(string firstName, string lastName)
        {
            FirstName.SendKeys(firstName);
            LastName.SendKeys(lastName);
        }

        private void EnterFrequentFlyerNumber(string frequentFLyerNumber)
        {
            FrequentFlyerNumber.SendKeys(frequentFLyerNumber);
        }

        private void EnterAge(string age)
        {
            Age.SendKeys(age);
        }

        private void EnterGrossAnnualIncome(string income)
        {
            GrossAnnualIncome.SendKeys(income);
        }

        public ApplicationCompletePage SubmitApplication()
        {
            ApplyButton.Click();

            return new ApplicationCompletePage(Driver);
        }
    }
}
