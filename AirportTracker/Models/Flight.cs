using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirportTracker.Models
{
    public class Flight
    {
        public int FlightId { get; set; }
        [Required(ErrorMessage = "Price is Required")]
        [Range(1, 3000)]
        public double FlightPrice { get; set; }
        [Required(ErrorMessage = "Takeoff is Required")]
        public DateTime TakeOff { get; set; }

        [Required(ErrorMessage = "Please include passenger total")]
        [Range(1, Int32.MaxValue)]
        public int PassengerTotal { get; set; }
        public int? PassengerCount { get; set; }
        //Might not add to database, if it doesn't, just add in the post for the method that updates passenger count. passengerCount.PassengerCount++.
        public void AddPassengerCount()
        {
            PassengerCount++;
        }
        [NotMapped]
        public string DisplayLocation => $"{DepartureAirport} to {ArrivalAirport}";

        public Airport? Airport { get; set; }
        [ForeignKey("DepartureAirport")]
        [Required(ErrorMessage = "Departure Airport is Required")]
        public int DepartureAirportId { get; set; }
        public string DepartureAirport { get; set; } = string.Empty;
        [ForeignKey("ArrivalAirport")]
        [Required(ErrorMessage = "Arrival Airport is Required")]
        public int ArrivalAirportId { get; set; }
        public string ArrivalAirport { get; set; } = string.Empty;
        
        public Employee? Employee { get; set; }
        public Aircraft? Aircraft { get; set; }
        [ForeignKey("AircraftId")]
        [Required(ErrorMessage = "Aircraft is Required")]
        public int AircraftId {  get; set; }

        public Terminal? Terminal { get; set; }
        [ForeignKey("TerminalId")]
        [Required(ErrorMessage = "Terminal is Required")]
        public int TerminalId { get; set; }
    }
}
