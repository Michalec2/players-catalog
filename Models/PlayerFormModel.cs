using System.ComponentModel.DataAnnotations;

namespace players_catalog.Models
{
    public class PlayerFormModel
    {
        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        public string Name { get; set; }

        [Range(1, 120, ErrorMessage = "Wiek musi być pomiędzy 1 a 120.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Pozycja jest wymagana.")]
        [StringLength(50, ErrorMessage = "Pozycja nie może być dłuższa niż 50 znaków.")]
        public string Position { get; set; }

        [Range(1, 120, ErrorMessage = "Wiek musi być pomiędzy 1 a 120.")]
        public int TeamId { get; set; }
    }
}
