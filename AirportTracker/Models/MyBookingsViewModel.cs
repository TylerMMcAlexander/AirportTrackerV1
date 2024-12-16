namespace AirportTracker.Models
{
    public class MyBookingsViewModel
    {
        public IEnumerable<Booking> UpcomingFlights { get; set; }
        public IEnumerable<Booking> PriorFlights { get; set; }
    }
}
