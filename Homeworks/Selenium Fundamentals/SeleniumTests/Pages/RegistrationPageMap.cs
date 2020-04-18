
namespace SeleniumTests.Pages
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System.Collections.Generic;
    using System.Linq;

    public partial class RegistrationPage
    {
        public IWebElement FirstName => _driver.FindElement(By.Id("name_3_firstname"));

        public IWebElement LastName => _driver.FindElement(By.Id("name_3_lastname"));

        public List<IWebElement> MatrialStatus => _driver.FindElements(By.Name("radio_4[]")).ToList();

        public List<IWebElement> Hobbies => _driver.FindElements(By.Name("checkbox_5[]")).ToList();

        public IWebElement Country => _driver.FindElement(By.Id("dropdown_7"));

        public SelectElement CountryOption => new SelectElement(this.Country);

        public IWebElement Month => _driver.FindElement(By.Id("mm_date_8"));

        public SelectElement MonthOption => new SelectElement(this.Month);

        public IWebElement Day => _driver.FindElement(By.Id("dd_date_8"));

        public SelectElement DayOption => new SelectElement(this.Day);

        public IWebElement Year => _driver.FindElement(By.Id("yy_date_8"));

        public SelectElement YearOption => new SelectElement(this.Year);

        public IWebElement Phone => _driver.FindElement(By.Id("phone_9"));

        public IWebElement UserName => _driver.FindElement(By.Id("username"));

        public IWebElement Email => _driver.FindElement(By.Id("email_1"));

        public IWebElement UploadPicButton => _driver.FindElement(By.Id("profile_pic_10"));

        public IWebElement Description => _driver.FindElement(By.Id("description"));

        public IWebElement Password => _driver.FindElement(By.Id("password_2"));

        public IWebElement ConfirmPassword => _driver.FindElement(By.Id("confirm_password_password_2"));

        public IWebElement SubmitButton => _driver.FindElement(By.Name("pie_submit"));       

        public IWebElement NameErrorMessage => _driver.FindElement(By.XPath(@"//*[@id=""pie_register""]/li[1]/div[1]/div[2]/span"));

        public IWebElement HobbyErrorMessage => _driver.FindElement(By.XPath(@"//*[@id=""pie_register""]/li[3]/div/div[2]/span"));

        public IWebElement UsernameErrorMessage => _driver.FindElement(By.XPath(@"//*[@id=""pie_register""]/li[7]/div/div/span"));

        public IWebElement PhoneErrorMessage => _driver.FindElement(By.XPath(@"//*[@id=""pie_register""]/li[6]/div/div/span"));

        public IWebElement HeaderMessage => _driver.FindElement(By.TagName("h1"));

        public IWebElement EmailErrorMessage => _driver.FindElement(By.XPath(@"//*[@id=""pie_register""]/li[8]/div/div/span"));

        public IWebElement PasswordErrorMessage => _driver.FindElement(By.XPath(@"//*[@id=""pie_register""]/li[12]/div/div/span"));
    }
}
