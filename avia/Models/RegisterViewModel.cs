using System.ComponentModel.DataAnnotations;

namespace avia.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
    public class LoginViewModel
    {
        public string Email { get; set; }

        
        public string Password { get; set; }
       
        public string Login { get; set; }
    }
}
