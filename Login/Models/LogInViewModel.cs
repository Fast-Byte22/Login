using System.ComponentModel.DataAnnotations;

namespace Login.Models
{
    public class LogInViewModel
    {
        [Required(ErrorMessage = "This field is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage ="This field is required.")]
        public string Password { get; set; }

    }
}
