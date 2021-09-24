using System;
using System.Collections.Generic;

#nullable disable

namespace Login.Context
{
    public partial class Usertable
    {
        public int Id { get; set; }
        public string CreateTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string DateOfBirth { get; set; }
    }
}
