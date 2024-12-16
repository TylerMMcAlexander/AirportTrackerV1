using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AirportTracker.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AirportTracker.Controllers
{
    [Authorize(Roles = "Admin , AirportAdmin")]
    public class AdminController : BaseController
    {
            
        private string filterTypeglobal;
        private readonly AirportContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager;
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        // this makes the shtuff work
        public AdminController(AirportContext context, SignInManager<User> signInManager, IHostingEnvironment hostingEnvironment, Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> roleManager, Microsoft.AspNetCore.Identity.UserManager<User> userManager) : base(context)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        // works somehow by the magic pixie dust sneezed out by albus dumbledore 
        //
        [HttpPost]
        public async Task<IActionResult> AddEmployee(string id, string position, int airportId, string isAdmin)
        {
            try
            {
                IdentityRole adminRole = await _roleManager.FindByNameAsync("Admin");
                if (isAdmin == null)
                {
                    isAdmin = "False";
                }
                if (adminRole != null && (ModelState.IsValid && isAdmin == "True" || isAdmin == "False"))
                {
                    User user = await _userManager.FindByIdAsync(id);
                    user.employed = true;
                    //await _userManager.AddToRoleAsync(user, adminRole.Name);
                    Employee employee = new Employee()
                    {
                        User = user,
                        Position = position,
                        AirportId = airportId,
                        UserId = user.Id
                    };
                    if (isAdmin == "True")
                    {
                        await _userManager.AddToRoleAsync(user, "AirportAdmin");
                    }
                    var result = await _userManager.UpdateAsync(user);
                    _context.Add(employee);
                    await _context.SaveChangesAsync();
                    //await _signInManager.RefreshSignInAsync(user);
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Add Employee Failed To Post: {ex.Message}");
                return RedirectToAction("Index", "Flight");
            }
            
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(string id)
        {
            try
            {
                List<Employee> employees = new List<Employee>();
                List<Airport> Airports = new List<Airport>();
                IQueryable<Airport> Aquery = _context.Airports.OrderBy(e => e.AirportId);
                foreach (Airport e in Aquery)
                { Airports.Add(e); }
                ViewBag.Airports = Airports;
                IQueryable<Employee> query = _context.Employees.OrderBy(e => e.User.Id);
                employees = query.ToList();
                Employee employee = new Employee();
                foreach (Employee ep in employees)
                {
                    if (ep.UserId == id)
                    {
                        employee = ep;
                    }
                }
                User user = _context.Users.FirstOrDefault(e => e.Id == id);

                if (await _userManager.IsInRoleAsync(user, "AirportAdmin"))
                {
                    ViewBag.UserIsInRole = "True";
                }
                return View(employee);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Edit Employee Failed To Get: {ex.Message}");
                return RedirectToAction("Index", "Flight");
            }


        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(Employee employee, string isAdmin)
        {
            User user = _context.Users.FirstOrDefault(e => e.Id == employee.UserId);
            if(isAdmin == null)
            {
                isAdmin = "False";
            }
            if (!ModelState.IsValid && isAdmin != "False")
            {
                if (await _userManager.IsInRoleAsync(user, "AirportAdmin"))
                {
                    ViewBag.UserIsInRole = "True";
                }
                return View(employee);
            }
            try
            {
                if (isAdmin == "True")
                {
                    await _userManager.AddToRoleAsync(user, "AirportAdmin");
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, "AirportAdmin");
                }
                var result = await _userManager.UpdateAsync(user);
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                Console.WriteLine($"Edit Employee Failed To Post: {ex.Message}");
                return View(employee);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string? id)
        {
            try
            {
                List<User> Users = new List<User>();
                IQueryable<User> query = _context.Users.OrderBy(e => e.Id);

                foreach (User e in query)
                {
                    Users.Add(e);
                }

                ViewBag.Users = Users;

                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.UserId == id);
                if (employee == null)
                {
                    return NotFound();
                }
                return View(employee);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Admin Delete Failed To Get: {ex.Message}");
                return RedirectToAction("Index", "Flight");
            }
            
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmedDelete(string id)
        {
            try
            {
                User user = _context.Users.FirstOrDefault(e => e.Id == id);
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.UserId == id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    await _userManager.RemoveFromRoleAsync(user, "AirportAdmin");
                }
                var result = await _userManager.UpdateAsync(user);
                await _context.SaveChangesAsync();
                return RedirectToAction("EmployeeManager");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Admin Delete Failed To Post: {ex.Message}");
                return View(id);
            }
            
        }

        public async Task<IActionResult> Viewsroles() 
        {
            try
            {
                var _user = await _userManager.FindByNameAsync(User.Identity.Name);
                var roles = await _userManager.GetRolesAsync(_user);

                return View(roles);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"View Roles Task Failed: {ex.Message}");
                return RedirectToAction("Index", "Flight");
            }
        }

        public async Task<IActionResult> EmployeeManager(User user)
        {
            try
            {
                Employee airportAdmin = new Employee();
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                List<User> Users = new List<User>();
                List<Airport> Airports = new List<Airport>();
                Dictionary<User, string> employees = new Dictionary<User, string>();

                IQueryable<User> query = _context.Users.OrderBy(e => e.Id);
                IQueryable<Airport> Aquery = _context.Airports.OrderBy(e => e.AirportId);
                IQueryable<Employee> Equery = _context.Employees.OrderBy(e => e.User.Id);
                foreach (User e in query)
                {
                    Users.Add(e);
                }

                foreach (User e in Users)
                {
                    if (e.Id == userId)
                    {
                        user = e;
                    }
                }
                if (await _userManager.IsInRoleAsync(user, "AirportAdmin"))
                {
                    airportAdmin = _context.Employees.FirstOrDefault(e => e.UserId == userId);
                }
                foreach (var employee in Equery)
                {

                    User u = await _userManager.FindByIdAsync(employee.UserId);
                    employees.Add(u, employee.Position);

                }

                if (await _userManager.IsInRoleAsync(user, "AirportAdmin"))
                {
                    foreach (User u in query)
                    {
                        bool isEmployee = false;
                        foreach (Employee e in Equery)
                        {
                            if (e.UserId == u.Id)
                            {
                                if (e.Airport == airportAdmin.Airport)
                                {
                                    isEmployee = true;
                                }
                            }
                        }
                        if (!isEmployee)
                        {
                            Users.Remove(u);
                        }
                    }
                }
                ViewBag.Employees = employees;



                foreach (Airport e in Aquery)
                { Airports.Add(e); }
                Console.WriteLine("*********** hi");

                ViewBag.Airports = Airports;

                return View(Users);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Employee Manager Task Failed: {ex.Message}");
                return RedirectToAction("Index", "Flight");
            }
            
        }

    }
}
