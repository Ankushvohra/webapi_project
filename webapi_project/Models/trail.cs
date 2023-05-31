using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_project.Models
{
    public class trail
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]
        public string Distance { get; set; }
        [Required]
        public string Elevation { get; set; }

        public DateTime Datecreated { get; set; }

        public enum Difficultytype { Easy,Moderate,Difficult}

        public Difficultytype Difficulty { get; set; }

        public int NationalParkId { get; set; }

        [ForeignKey("NationalParkId")]
        public NationalPark NationalPark { get; set; }
    }
}
