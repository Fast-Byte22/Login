using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class LogInViewModel
    {

        [DataType(DataType.EmailAddress)]
        [MaxLength(255, ErrorMessage = "Email adress is too long.")]
        [MinLength(6, ErrorMessage = "Email adress is too short.")]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [MaxLength(255, ErrorMessage = "Password is too long")]
        [MinLength(8, ErrorMessage = "Password is too short.")]
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }

    }
}
