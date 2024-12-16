using AirportTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Authorization;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace AirportTracker.Controllers
{
    public class AirportController : BaseController
    {
        private readonly IHostingEnvironment hostingEnviroment;
        public AirportController(AirportContext ctx, IHostingEnvironment hosting) : base(ctx)
        {
            this.hostingEnviroment = hosting;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListAirport(Airport airport)
        {
            try
            {
                var airports = Context.Airports.ToList(); // Use the Context from the base controller
                return View(airports);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"List Airport Failed: {ex.Message}");
                return RedirectToAction("Index", "Flight");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddAirport()
        {
            try
            {
                return View(new Airport());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Add Airport Get Failed: {ex.Message}");
                return RedirectToAction("Index", "Flight");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddAirport(Airport airport)
        {
            try
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                ViewBag.Errors = errors;

                if (ModelState.IsValid)
                {
                    string fileName = null;
                    if (airport.Photo != null)
                    {
                        string uploadFolder = Path.Combine(hostingEnviroment.WebRootPath, "Images/Airports");
                        fileName = Guid.NewGuid().ToString() + "_" + airport.Photo.FileName;
                        string filePath = Path.Combine(uploadFolder, fileName);
                        airport.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                        airport.FileName = fileName;
                    }
                    else
                    {
                        var existingAirport = Context.Airports.Find(airport.AirportId);
                        airport.FileName = existingAirport.FileName;
                    }
                    if (airport.AirportId == 0)
                    {
                        Context.Airports.Add(airport);
                    }
                    else
                    {
                        var existingAirport = Context.Airports.Find(airport.AirportId);
                        if (existingAirport != null)
                        {
                            Context.Entry(existingAirport).CurrentValues.SetValues(airport);
                        }
                    }
                    Context.SaveChanges();
                    return RedirectToAction("ListAirport", "Airport");
                }
                else
                {
                    return View(airport);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Add Airport Post Failed: {ex.Message}");
                return View(airport);
            }

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditAirport(int id)
        {
            try
            {
                Airport airport = Context.Airports.Find(id);
                return View("AddAirport", airport);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Edit Airport Failed To Get: {ex.Message}");
                return RedirectToAction("Index", "Flight");
            }

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ViewAircraft(int id)
        {
            var flights = await Context.Flights
                                    .Where(f => f.DepartureAirportId == id)
                                    .ToListAsync();

            var aircraftList = new List<Aircraft>();

            foreach (var flight in flights)
            {
                if (flight.AircraftId != 0)
                {
                    var aircraft = await Context.Aircrafts.FindAsync(flight.AircraftId);
                    if (aircraft != null && !aircraftList.Contains(aircraft))
                    {
                        aircraftList.Add(aircraft);
                    }
                }
            }

            return View(aircraftList);
        }



        [HttpGet]
        public async Task<IActionResult> ViewAirport(int Id)
        {
            try
            {
                var airport = Context.Airports.Find(Id);

                var flights = await Context.Flights
                                        .Where(f => f.DepartureAirportId == Id)
                                        .ToListAsync();

                ViewBag.Departures = flights;
                ViewBag.Airport = airport;
                return View("AirportDetails", airport);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"View Airport Failed To Get: {ex.Message}");
                return RedirectToAction("Index", "Flight");
            }

        }

        [HttpGet]
        public IActionResult ViewMap(int Id)
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"View Map Failed To Get: {ex.Message}");
                return RedirectToAction("Index", "Flight");
            }

        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAirport(int id)
        {
            try
            {
                var airport = Context.Airports.Find(id);
                return View(airport);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Delete Airport Failed To Get: {ex.Message}");
                return RedirectToAction("Index", "Flight");

            }

        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteAirport(Airport airport)
        {
            try
            {
                Airport airport2 = Context.Airports.FirstOrDefault(a => a.AirportId == airport.AirportId);
                Context.Airports.Remove(airport2);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Delete Airport Failed To Post: {ex.Message}");
                return View(airport);
            }


            return RedirectToAction("ListAirport", "Airport");
        }
        public ActionResult FilterData(string searchString, string filterType)
        {
            try
            {
                List<Airport> airports = new List<Airport>();
                IQueryable<Airport> query = Context.Airports.OrderBy(e => e.AirportId);
                List<Airport> outputAirports = new List<Airport>();
                foreach (Airport e in query)
                { airports.Add(e); }
                if (filterType == "AirportName")
                {
                    foreach (Airport e in airports)
                    {
                        if (e.Name.ToLower().Contains(searchString.ToLower()))
                        {

                            outputAirports.Add(e);
                        }
                    }
                }
                else if (filterType == "AirportState")
                {
                    foreach (Airport e in airports)
                    {
                        if (e.State.ToLower().Contains(searchString.ToLower()))
                        {
                            outputAirports.Add(e);
                        }
                    }
                }
                else if (filterType == "AirportCity")
                {
                    foreach (Airport e in airports)
                    {
                        if (e.City.ToLower().Contains(searchString.ToLower()))
                        {
                            outputAirports.Add(e);
                        }
                    }
                }
                ViewBag.FilterType = filterType;
                return View("ListAirport", outputAirports);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Filter Data Failed Task: {ex.Message}");
                return RedirectToAction("Index", "Flight");
            }

        }
        [HttpPost]
        public IActionResult FilterType(string filterType)
        {
            try
            {
                List<Airport> airports = new List<Airport>();
                IQueryable<Airport> query = Context.Airports.OrderBy(e => e.AirportId);
                foreach (Airport e in query)
                { airports.Add(e); }
                if (filterType == "AirportName")
                {
                    ViewBag.FilterType = filterType;
                }
                else if (filterType == "AirportState")
                {
                    ViewBag.FilterType = filterType;
                }
                else if (filterType == "AirportCity")
                {
                    ViewBag.FilterType = filterType;
                }
                return View("ListAirport", airports);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Filter Type Failed To Post: {ex.Message}");
                return View(filterType);
            }

        }
    }
}
