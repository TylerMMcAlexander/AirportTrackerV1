using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportTracker.Models
{
    public class Airport
    {
        [Required]
        [Key]
        public int AirportId { get; set; }
        [Required(ErrorMessage = "State is required.")]
        public string State { get; set; } = string.Empty;
        [Required(ErrorMessage = "City is required.")]
        public string City { get; set; } = string.Empty;
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Shorthand is required.")]
        public string Shorthand { get; set; } = string.Empty;

        [NotMapped]
        public IFormFile? Photo { get; set; }

        [Required(ErrorMessage = "A video url is required.")]
        public string? VideoURL { get ; set; }
        [Required(ErrorMessage = "A photo is requied.")]
        public string? FileName { get; set; }
        [Required(ErrorMessage = "A description is required.")]
        public string? Description { get; set; }
    }
}
