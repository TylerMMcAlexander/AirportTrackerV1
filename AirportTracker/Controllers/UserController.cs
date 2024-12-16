using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AirportTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AirportTracker.Controllers
{
    public class UserController : BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        // Add AirportContext parameter to the constructor
        public UserController(AirportContext ctx, UserManager<User> userMngr, RoleManager<IdentityRole> roleMngr)
            : base(ctx) // Pass the context to the base constructor
        {
            userManager = userMngr;
            roleManager = roleMngr;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                List<User> users = new List<User>();
                foreach (User user in userManager.Users)
                {
                    user.Rolename = await userManager.GetRolesAsync(user);
                    users.Add(user);
                }
                UserViewModel model = new UserViewModel
                {
                    Users = users,
                    Roles = roleManager.Roles
                };
                return View(model);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"User Index Failed To Load");
                return RedirectToAction("Index", "Flight");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                User user = await userManager.FindByIdAsync(id);
                if (user != null)
                {
                    IdentityResult result = await userManager.DeleteAsync(user);
                    if (!result.Succeeded)
                    {
                        string errorMessage = "";
                        foreach (IdentityError error in result.Errors)
                        {
                            errorMessage += error.Description + " | ";
                        }
                        TempData["message"] = errorMessage;
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Delete Failed To Post: {ex.Message}");
                return View("Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddToAdmin(string id)
        {
            try
            {
                IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");
                if (adminRole == null)
                {
                    TempData["message"] = "Admin role does not exist."; // Fixed missing semicolon
                }
                else
                {
                    User user = await userManager.FindByIdAsync(id); // Changed to find the user by ID
                    if (user != null)
                    {
                        await userManager.AddToRoleAsync(user, adminRole.Name);
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Add To Admin Failed To Post: {ex.Message}");
                return View("Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromAdmin(string id)
        {
            try
            {
                User user = await userManager.FindByIdAsync(id);
                if (user != null)
                {
                    await userManager.RemoveFromRoleAsync(user, "Admin");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Remove From Admin Failed To Post: {ex.Message}");
                return View("Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            try
            {
                IdentityRole role = await roleManager.FindByIdAsync(id);
                if (role != null)
                {
                    await roleManager.DeleteAsync(role);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Delete Role Failed To Post: {ex.Message}");
                return View("Index");
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateAdminRole()
        {
            try
            {
                IdentityRole adminRole = await roleManager.FindByNameAsync("Admin");
                if (adminRole == null)
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Create Admin Role Failed To Post: {ex.Message}");
                return View("Index");

            }
        }
    }
}
