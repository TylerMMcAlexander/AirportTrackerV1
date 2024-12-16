using AirportTracker.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirportTracker.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class FlightController : BaseController
    {

        public FlightController(AirportContext ctx) : base(ctx) { }

        public IActionResult Index()
        {
            try
            {
                var userId = User.Identity?.GetUserId();
                var nextFlight = GetNextBookedFlight(userId);
                if (nextFlight != null && nextFlight.TakeOff > DateTime.Now)
                {
                    ViewBag.NextFlightNotification = $"Your next flight is to {nextFlight.DisplayLocation} on {nextFlight.TakeOff.ToShortDateString()}";
                }
                List<Flight> flight = setFlightData();

                return View(flight);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Index Failed To Get: {ex.Message}");
                return RedirectToAction("Index", "Home");
            }

        }

        public Flight GetNextBookedFlight(string userId)
        {
            try
            {
                var currentDate = DateTime.Now.AddHours(24);
                var nextFlight = (from b in Context.Bookings
                                  join f in Context.Flights on b.FlightId equals f.FlightId
                                  where b.UserId == userId && f.TakeOff < currentDate
                                  orderby f.TakeOff
                                  select f).FirstOrDefault();
                return nextFlight;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Get Next Booked Flight Failed: {ex.Message}");
                return null;
            }
        }
        public List<Flight> setFlightData()
        {
            try
            {
                List<Airport> Airports = new List<Airport>();
                List<Terminal> Terminals = new List<Terminal>();
                IQueryable<Airport> Aquery = Context.Airports.OrderBy(e => e.AirportId);
                foreach (Airport e in Aquery)
                { Airports.Add(e); }
                ViewBag.Airports = Airports;
                List<Flight> flight = Context.Flights.OrderBy(e => e.AircraftId).Include(t => t.Terminal).ToList();
                List<Terminal> terminal = Context.Terminals.OrderBy(t => t.TerminalId).ToList();
                List<Aircraft> aircrafts = new List<Aircraft>();
                IQueryable<Aircraft> aquery = Context.Aircrafts.OrderBy(e => e.AircraftId);

                foreach (Aircraft air in aquery)
                {
                    aircrafts.Add(air);
                }
                ViewBag.Aircrafts = aircrafts;
                return flight;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Set Flight Data Failed: {ex.Message}");
                return null;
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult AddFlight()
        {
            try
            {
                List<Airport> Airports = new List<Airport>();
                IQueryable<Airport> Aquery = Context.Airports.OrderBy(e => e.AirportId);
                foreach (Airport e in Aquery)
                { Airports.Add(e); }
                ViewBag.Airports = Airports;
                List<Aircraft> aircrafts = new List<Aircraft>();
                IQueryable<Aircraft> aquery = Context.Aircrafts.OrderBy(e => e.AircraftId);

                foreach (Aircraft air in aquery)
                {
                    aircrafts.Add(air);
                }
                ViewBag.Aircrafts = aircrafts;

                List<Terminal> Terminals = new List<Terminal>();
                IQueryable<Terminal> tquery = Context.Terminals.OrderBy(e => e.TerminalId);
                foreach (Terminal t in tquery)
                {
                    Terminals.Add(t);
                }
                ViewBag.Terminals = Terminals;
                return View(new Flight());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Add Flight Failed To Get");
                return View("Index");
            }

        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddFlight(Flight flight)
        {
            try
            {
                List<Airport> Airports = new List<Airport>();
                IQueryable<Airport> Aquery = Context.Airports.OrderBy(e => e.AirportId);
                foreach (Airport e in Aquery)
                { Airports.Add(e); }
                ViewBag.Airports = Airports;
                List<Aircraft> aircrafts = new List<Aircraft>();
                IQueryable<Aircraft> aquery = Context.Aircrafts.OrderBy(e => e.AircraftId);

                foreach (Aircraft air in aquery)
                {
                    aircrafts.Add(air);
                }
                ViewBag.Aircrafts = aircrafts;
                List<Terminal> Terminals = new List<Terminal>();
                IQueryable<Terminal> tquery = Context.Terminals.OrderBy(e => e.TerminalId);
                foreach (Terminal t in tquery)
                {
                    Terminals.Add(t);
                }
                ViewBag.Terminals = Terminals;
                if (ModelState.IsValid)
                {
                    if (flight.PassengerTotal <= aircrafts.Find(e => e.AircraftId == flight.AircraftId).Capacity) 
                    {
                        var departureAirport = Context.Airports
                            .FirstOrDefault(a => a.AirportId == flight.DepartureAirportId)?.Name;
                        var arrivalAirport = Context.Airports
                            .FirstOrDefault(a => a.AirportId == flight.ArrivalAirportId)?.Name;

                        if (departureAirport != null)
                        {
                            flight.DepartureAirport = departureAirport;
                        }

                        if (arrivalAirport != null)
                        {
                            flight.ArrivalAirport = arrivalAirport;
                        }
                        flight.PassengerCount = 0;
                        Context.Flights.Add(flight);
                        await Context.SaveChangesAsync();
                        return RedirectToAction("Index");
                    }
                }
                
                return View(flight);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Add Airport Failed To Post: {ex.Message}");
                return View(flight);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> EditFlight(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<Airport> Airports = new List<Airport>();
                    IQueryable<Airport> Aquery = Context.Airports.OrderBy(e => e.AirportId);
                    foreach (Airport e in Aquery)
                    { Airports.Add(e); }
                    ViewBag.Airports = Airports;
                    List<Aircraft> aircrafts = new List<Aircraft>();
                    Flight currentFlight = new Flight();
                    IQueryable<Aircraft> aquery = Context.Aircrafts.OrderBy(e => e.AircraftId);
                    List<Flight> flights = Context.Flights.OrderBy(e => e.AircraftId).ToList();
                    foreach (Aircraft air in aquery)
                    {
                        aircrafts.Add(air);
                    }
                    ViewBag.Aircrafts = aircrafts;
                    foreach (Flight newFlight in flights)
                    {
                        if (newFlight.FlightId == id)
                        {
                            currentFlight = newFlight;
                        }
                    }

                    return View(currentFlight);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Edit Flight Failed To Get: {ex.Message}");
                return View("Index");
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> EditFlight(Flight currentFlight)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Context.Flights.Update(currentFlight);
                    await Context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    Console.WriteLine($"Edit Flight Failed To Post: {ex.Message}");
                }
            }
            return View(currentFlight);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                List<Airport> Airports = new List<Airport>();
                IQueryable<Airport> Aquery = Context.Airports.OrderBy(e => e.AirportId);
                foreach (Airport e in Aquery)
                { Airports.Add(e); }
                ViewBag.Airports = Airports;
                var flight = await Context.Flights.FirstOrDefaultAsync(m => m.FlightId == id);
                if (flight == null)
                {
                    return NotFound();
                }
                return View(flight);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Delete Flight Failed To Get: {ex.Message}");
                return View("Index");
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmedDelete(int id)
        {
            try
            {
                var flight = await Context.Flights.FirstOrDefaultAsync(m => m.FlightId == id);
                if (flight != null)
                {
                    Context.Flights.Remove(flight);
                }
                await Context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Confirmed Delete Task Failed: {ex.Message}");
                return View(id);
            }

        }

        [HttpGet]
        public IActionResult BookFlight(int flightId)
        {
            try
            {
                var flight = Context.Flights.FirstOrDefault(f => f.FlightId == flightId);

                ViewBag.Flight = flight;
                var bookingModel = new Booking
                {
                    Flight = flight
                };

                return View(bookingModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Book Flight Failed To Get: {ex.Message}");
                return View("Index");
            }

        }



        [HttpPost]
        public IActionResult BookFlight(Booking booking)
        {
            try
            {
                var userId = User.Identity?.GetUserId();

                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Login", "Account");
                }

                var selectedFlight = Context.Flights.FirstOrDefault(f => f.FlightId == booking.FlightId);

                if (selectedFlight != null)
                {
                    if (selectedFlight.PassengerCount + booking.NumberOfSeats <= selectedFlight.PassengerTotal)
                    {
                        selectedFlight.PassengerCount += booking.NumberOfSeats;
                        Context.SaveChanges();

                        var newBooking = new Booking
                        {
                            FlightId = booking.FlightId,
                            NumberOfSeats = booking.NumberOfSeats,
                            BookingDate = DateTime.Now,
                            UserId = userId
                        };

                        Context.Bookings.Add(newBooking);
                        Context.SaveChanges();

                        return RedirectToAction("BookingConfirmation", new { bookingId = booking.BookingId });
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Not enough available seats for this flight");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Selected flight does not exist");
                }

                return View(booking);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Book Flight Failed To Post: {ex.Message}");
                return View(booking);
            }
        }

        public IActionResult BookingConfirmation(int BookingId)
        {
            try
            {
                var booking = Context.Bookings.Include(b => b.Flight).FirstOrDefault(b => b.BookingId == b.BookingId);
                if (booking != null)
                {
                    return View(booking);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Booking Confirmation Failed: {ex.Message}");
                return View("Index");
            }

        }

        [HttpGet]
        public IActionResult CancelBooking(int id)
        {
            try
            {
                var booking = Context.Bookings
                                 .Include(b => b.Flight)
                                 .FirstOrDefault(b => b.BookingId == id);

                if (booking == null)
                {
                    return NotFound();
                }

                return View(booking);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cancel Booking Failed To Get");
                return View("Index");
            }

        }
        [HttpPost]
        public async Task<IActionResult> ConfirmCancelBooking(int bookingId)
        {
            try
            {
                var booking = await Context.Bookings
                                        .Include(b => b.Flight)
                                        .FirstOrDefaultAsync(b => b.BookingId == bookingId);

                if (booking == null)
                {
                    return NotFound();
                }

                if (booking.Flight != null && booking.NumberOfSeats > 0)
                {
                    booking.Flight.PassengerCount -= booking.NumberOfSeats;

                    if (booking.Flight.PassengerCount < 0)
                    {
                        booking.Flight.PassengerTotal = 0;
                    }
                }

                Context.Bookings.Remove(booking);
                await Context.SaveChangesAsync();

                return RedirectToAction("MyBookings");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Confirm Cancel Booking Failed: {ex.Message}");
                return View(bookingId);
            }

        }

        [HttpGet]
        public IActionResult MyBookings()
        {
            try
            {
                var userId = User.Identity?.GetUserId();
                if (string.IsNullOrEmpty(userId))
                {
                    return RedirectToAction("Login", "Account");
                }

                // Load bookings with their associated Flight
                var userBookings = Context.Bookings
                                  .Include(b => b.Flight)  // Include the Flight property
                                  .Where(b => b.UserId == userId)
                                  .ToList();

                var upcomingFlights = userBookings.Where(b => b.Flight?.TakeOff >= DateTime.Now).ToList();

                var priorFlights = userBookings.Where(b => b.Flight?.TakeOff <= DateTime.Now).ToList();

                var model = new MyBookingsViewModel
                {
                    UpcomingFlights = upcomingFlights,
                    PriorFlights = priorFlights
                };

                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"My Bookings Failed To Get: {ex.Message}");
                return View("Index");
            }

        }

        public ActionResult FilterData(string searchString, string filterType)
        {
            try
            {
                List<Flight> flight = setFlightData();
                IQueryable<Flight> query = Context.Flights.OrderBy(e => e.FlightId);
                List<Airport> airports = new List<Airport>();
                IQueryable<Airport> Aquery = Context.Airports.OrderBy(e => e.AirportId);
                int airportId = 0;
                foreach (Airport e in Aquery)
                { airports.Add(e); }
                if (filterType == "Id")
                {
                    query = query.Where(e => e.FlightId.Equals(int.Parse(searchString)));
                    flight = query.ToList();
                }
                else if (filterType == "DepartureState")
                {
                    List<Flight> flight2 = new List<Flight>();
                    List<int> departureIds = new List<int>();
                    foreach (Airport e in airports)
                    {

                        if (e.Name.ToLower().Contains(searchString.ToLower()))
                        {
                            airportId = e.AirportId;
                            departureIds.Add(airportId);
                        }
                    }
                    foreach (Flight e in query)
                    {
                        foreach (int id in departureIds)
                        {
                            if (e.DepartureAirportId == id)
                            {
                                flight2.Add(e);
                            }
                        }
                    }
                    flight = flight2;
                }
                else if (filterType == "ArrivalState")
                {
                    List<Flight> flight2 = new List<Flight>();
                    List<int> departureIds = new List<int>();
                    foreach (Airport e in airports)
                    {

                        if (e.Name.ToLower().Contains(searchString.ToLower()))
                        {
                            airportId = e.AirportId;
                            departureIds.Add(airportId);
                        }
                    }
                    foreach (Flight e in query)
                    {
                        foreach (int id in departureIds)
                        {
                            if (e.ArrivalAirportId == id)
                            {
                                flight2.Add(e);
                            }
                        }
                    }
                    flight = flight2;
                }
                ViewBag.FilterType = filterType;
                return View("Index", flight);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Filter Data Get Failed: {ex.Message}");
                return View("Index");
            }

        }
        [HttpPost]
        public IActionResult FilterType(string filterType)
        {
            try
            {
                List<Flight> flight = setFlightData();
                if (filterType == "Id")
                {
                    ViewBag.FilterType = filterType;
                }
                else if (filterType == "DepartureState")
                {
                    ViewBag.FilterType = filterType;
                }
                else if (filterType == "ArrivalState")
                {
                    ViewBag.FilterType = filterType;
                }
                return View("Index", flight);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Filter Type Failed To Post: {ex.Message}");
                return View("Index");
            }

        }


    }
}
