using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportTracker.Models
{
    public class Terminal
    {
        [Key]
        public int TerminalId { get; set; }
        [Required(ErrorMessage = "Please include the terminal name.")]
        public string TerminalName { get; set; } = string.Empty;
        
        public Airport? Airport { get; set; } = null!;

        [ForeignKey("Airport")]
        [Required(ErrorMessage = "Airport is required.")]
        public int AirportId { get; set; }

    }
}
