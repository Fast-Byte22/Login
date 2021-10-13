using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Models
{
    public class SignUpViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string RePassword { get; set; }
        public string Password { get; set; }
        public string DateOfBirth { get; set; }
    }
}
