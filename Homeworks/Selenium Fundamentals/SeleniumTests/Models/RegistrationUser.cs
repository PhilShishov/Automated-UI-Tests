using System.Collections.Generic;

namespace SeleniumTests.Models
{
    public class RegistrationUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<bool> MatrialStatus { get; set; }

        public List<bool> Hobbies { get; set; }

        public string Country { get; set; }

        public string Month { get; set; }

        public string Day { get; set; }

        public string Year { get; set; }

        public string Phone { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PicturePath { get; set; }

        public string Description { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
