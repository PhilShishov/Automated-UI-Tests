

namespace SeleniumTests.Factories
{
    using SeleniumTests.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    public static class UserFactory
    {
        public static RegistrationUser GenerateRegUser()
        {
            var _user = new RegistrationUser();
            _user.FirstName = "Philip";
            _user.LastName = "Shishov";
            _user.MatrialStatus = new List<bool>() { false, true, false };
            _user.Hobbies = new List<bool>() { false, true, false };
            _user.Country = "France";
            _user.Month = "5";
            _user.Day = "10";
            _user.Year = "1989";
            _user.Phone = "359999999999";
            _user.UserName = "philshishov";
            _user.Email = "philshishov@gmail.com";
            _user.PicturePath = Path.GetFullPath(@"..\..\..\logo.jpg");
            _user.Description = "Description";
            _user.Password = "admin1234";
            _user.ConfirmPassword = "admin1234";
            return _user;
        }
    }
}
