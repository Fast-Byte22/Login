using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Models
{
    public class SignUpViewModel
    {
        public int Id { get; set; }
        [StringLength(50)]
        [MaxLength(64)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string FirstName { get; set; }
        [StringLength(50)]
        [MaxLength(64)]
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [MaxLength(64)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [MaxLength(64)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [MaxLength(64)]
        public string RePassword { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string DateOfBirth { get; set; }
    }
}
