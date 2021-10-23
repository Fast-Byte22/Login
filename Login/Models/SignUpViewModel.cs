using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class SignUpViewModel 
    {

        public int Id { get; set; }

        [MaxLength(42, ErrorMessage = "First name is too long (42  max.)")]
        [MinLength(3, ErrorMessage = "First name must be at least 3 characters long.")]
        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression(@"^[A-zÀ-Ÿ-]*$", ErrorMessage = "Invalid characters.")]
        public string FirstName { get; set; }

        [MaxLength(42, ErrorMessage = "Last name is too long (42  max.)")]
        [MinLength(3, ErrorMessage = "Last name must be at least 3 characters long.")]
        [Required(ErrorMessage = "Name is required")]
        [RegularExpression(@"^[A - zÀ - Ÿ -] *$*$", ErrorMessage = "Invalid characters.")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [MaxLength(255,ErrorMessage ="Email adress is too long.")]
        [MinLength(6,ErrorMessage ="Email adress is too short.")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [MaxLength(255, ErrorMessage = "Password is too long")]
        [MinLength(8,ErrorMessage = "Password is too short.")]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm password is required")]
        public string RePassword { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Date of Birth is required")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string DateOfBirth { get; set; }
    }
}
