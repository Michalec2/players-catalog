using System.ComponentModel.DataAnnotations;

namespace players_catalog.Models
{
    public class TeamFormModel
    {
        [Required(ErrorMessage = "Nazwa jest wymagana.")]
        public string Name { get; set; }
        public int CoachId { get; set; }
    }
}
