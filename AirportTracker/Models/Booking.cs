namespace AirportTracker.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public Flight? Flight { get; set; }
        public int FlightId { get; set; }
        public int NumberOfSeats { get; set; }

        public User? User { get; set; }
        public string UserId { get; set; }
    }
}
