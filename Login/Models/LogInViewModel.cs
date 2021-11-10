using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class LogInViewModel
    {

        [Required(ErrorMessage = "This field is required.")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field is required.")]
        public string Password { get; set; }

    }
}
