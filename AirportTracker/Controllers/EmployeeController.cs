using AirportTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirportTracker.Controllers
{
    public class EmployeeController : Controller
    {
        //public AirportContext context { get; set; }
        //public EmployeeController(AirportContext ctx) => context = ctx;
        //public IActionResult Index()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public IActionResult Edit()
        //{
        //    return View();
        //}

        //[HttpGet]
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var employee = await context.Employees.FirstOrDefaultAsync(e => e.EmpId == id);
        //    return View(employee);
        //}
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    if (context.Employees == null)
        //    {
        //        return NotFound();
        //    }
        //    var employee = await context.Employees.FindAsync(id);
        //    if (employee != null)
        //    {
        //        context.Employees.Remove(employee);
        //    }
        //    await context.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //[HttpGet]
        //public IActionResult ListEmployee()
        //{
        //    var employees = context.Employees.ToList();
        //    return View(employees);
        //}
    }
}
