using System.ComponentModel.DataAnnotations;

namespace players_catalog.Models
{
    public class RegisterLoginViewModel
    {
        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        [MinLength(5, ErrorMessage = "Login musi mieć minimum 5 znaków")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Hasło jest wymagane.")]
        [MinLength(5, ErrorMessage = "Hasło musi mieć minimum 5 znaków")]
        public string Password { get; set; }
    }
}
