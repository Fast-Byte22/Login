using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Login.Models
{
    public partial class Usertable
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public string CreateTime { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string DateOfBirth { get; set; }
        public string PassHash { get; set; }
        public byte[]  salt { get; set; }
        public string Role { get; set; }
        public string Nick { get; set; }
    }
}
