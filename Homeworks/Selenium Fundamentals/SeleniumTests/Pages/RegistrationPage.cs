
namespace SeleniumTests.Pages
{
    using System.Collections.Generic;

    using OpenQA.Selenium;

    using SeleniumTests.Models;

    public partial class RegistrationPage
    {
        private IWebDriver _driver;

        public RegistrationPage(IWebDriver driver)
        {
            this._driver = driver;
        }
        public void GoToUrl()
        {
            _driver.Navigate().GoToUrl("http://demoqa.com/register/");
        }

        public void FillRegistrationForm(RegistrationUser user)
        {
            Type(FirstName, user.FirstName);
            Type(LastName, user.LastName);
            Type(UserName, user.UserName);
            Type(Password, user.Password);

            //FillManyOptionElements(MatrialStatus, user.MatrialStatus);
            //FillManyOptionElements(Hobbies, user.Hobbies);
            //CountryOption.SelectByText(user.Country);
            //MonthOption.SelectByValue(user.Month);
            //DayOption.SelectByText(user.Day);
            //YearOption.SelectByValue(user.Year);
            //Type(Phone, user.Phone);
            //Type(Email, user.Email);
            //UploadPicButton.Click();
            //_driver.SwitchTo().ActiveElement().SendKeys(user.PicturePath);
            //Type(Description, user.Description);
            //Type(ConfirmPassword, user.ConfirmPassword);

            SubmitButton.Click();
        }
        protected void Type(IWebElement element, string text)
        {
            element.Click();
            element.Clear();
            element.SendKeys(text);
        }

        private void FillManyOptionElements(List<IWebElement> elements, List<bool> values)
        {
            for (int i = 0; i < elements.Count; i++)
            {
                if (values[i])
                {
                    elements[i].Click();
                }
            }
        }
    }
}
