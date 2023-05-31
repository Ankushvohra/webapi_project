using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static webapi_project.Models.trail;

namespace webapi_project.Models.DTO
{
    public class TrailDTO
    {
        public int Id { get; set; }
        [Required]

        public string Name { get; set; }
        [Required]
        public string Distance { get; set; }
        [Required]
        public string Elevation { get; set; }

        public Difficultytype Difficulty { get; set; }

        public int NationalParkId { get; set; }

        [ForeignKey("NationalParkId")]
        public NationalPark NationalPark { get; set; }
    }
}
