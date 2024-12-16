using System.ComponentModel.DataAnnotations;

namespace AirportTracker.Models
{
    public class Aircraft
    {
        [Key]
        public int AircraftId { get; set; }
        [Required(ErrorMessage = "Please add the aircraft name.")]

        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please add the aircraft type.")]

        public string Type {  get; set; } = string.Empty;
        [Required(ErrorMessage = "Please add the aircraft capacity.")]

        public int Capacity { get; set; }
    }
}
