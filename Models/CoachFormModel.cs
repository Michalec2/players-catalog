using System.ComponentModel.DataAnnotations;

namespace players_catalog.Models
{
    public class CoachFormModel
    {
        [Required(ErrorMessage = "Imie jest wymagane.")]
        public string Name { get; set; }
        public int ExperienceYears { get; set; }
    }
}
