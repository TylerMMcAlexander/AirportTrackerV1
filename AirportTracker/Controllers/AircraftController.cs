using Microsoft.AspNetCore.Mvc;
using AirportTracker.Models;
using Microsoft.AspNetCore.Authorization;

namespace AirportTracker.Controllers
{
    public class AircraftController : BaseController
    {
        public AircraftController(AirportContext ctx) : base(ctx)
        {

        }
        public IActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Admin")]
        public IActionResult ListAircraft()
        {
            try
            {
                var aircraft = Context.Aircrafts.ToList();
                return View(aircraft);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"List Aircraft Failed: {ex.Message}");
                return RedirectToAction("Flight", "Index");
            }
            
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult AddAircraft()
        {
            try
            {
                return View(new Aircraft());
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Add Aircraft Get Failed: {ex.Message}");
                return RedirectToAction("ListAircraft");
            }
            
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult AddAircraft(Aircraft aircraft)
        {
            try
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                ViewBag.Errors = errors;

                if (ModelState.IsValid)
                {
                    Context.Aircrafts.Add(aircraft);
                    Context.SaveChanges();
                    return RedirectToAction("ListAircraft", "aircraft");
                }
                return View(aircraft);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Add Aircraft Post Failed: {ex.Message}");
                return View(aircraft);
            }
            
        }
    }
}
