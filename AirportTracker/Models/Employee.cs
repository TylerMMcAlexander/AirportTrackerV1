using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportTracker.Models
{
    public class Employee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int EmpId { get; set; }

        public string Position { get; set; }
        public Airport? Airport { get; set; }
        [ForeignKey("Airport")]
        public int AirportId { get; set; }
        public User? User { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public bool isEmployed()
        {
            return Position != null;
        }

    }
}
