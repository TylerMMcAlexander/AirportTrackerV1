using AirportTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirportTracker.Controllers
{
    public class TerminalController : BaseController
    {
        public TerminalController(AirportContext ctx) : base(ctx)
        {

        }
        public IActionResult ListTerminal()
        {
            try
            {
                List<Terminal> terminals = new List<Terminal>();
                IQueryable<Terminal> query = Context.Terminals.Include(a => a.Airport).OrderBy(a => a.Airport.Name);
                terminals = query.ToList();
                return View(terminals);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"List Terminal Failed: {ex.Message}");
                return RedirectToAction("Index", "Flight");
            }
            
        }

        [HttpGet]
        public IActionResult AddTerminal()
        {
            try
            {
                ViewBag.Airports = Context.Airports.OrderBy(a => a.Name).ToList();
                return View(new Terminal());
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Add Terminal Failed To Get: {ex.Message}");
                return View("ListTerminal");
            }
            
        }

        [HttpPost]
        public IActionResult AddTerminal(Terminal terminal)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Context.Terminals.Add(terminal);
                    Context.SaveChanges();
                    return RedirectToAction("ListTerminal", "Terminal");
                }
                return View(terminal);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Add Terminal Failed To Post: {ex.Message}");
                return View(terminal);
            }
        }
    }
}
