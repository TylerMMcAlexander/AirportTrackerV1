using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using AirportTracker.Models;
using System.Threading.Tasks;

//admin
//Admin123!
namespace AirportTracker.Controllers
{
    public class AccountController : BaseController // Change to inherit from BaseController
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public AccountController(AirportContext ctx, UserManager<User> _userManager, SignInManager<User> _signInManager)
            : base(ctx) 
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public ViewResult AccessDenied()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new User { UserName = model.Username, fName = model.fName, lName = model.lName };
                    Console.WriteLine("User name: " + user.lName);
                    var result = await userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                return View(model);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Register Failed To Post: {ex.Message}");
                return View(model); ;
            }
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Logout Failed To Post: {ex.Message}");
                return RedirectToAction("Index", "Account");
            }
        }

        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            try
            {
                var model = new LoginViewModel { ReturnUrl = returnURL };
                return View(model);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Login Failed To Get: {ex.Message}");
                return RedirectToAction("Index", "Account");
            }
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await signInManager.PasswordSignInAsync(
                        model.Username, model.Password, isPersistent: model.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                        {
                            return Redirect(model.ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                ModelState.AddModelError("", "Invalid username/password.");
                return View(model);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Login Failed To Post: {ex.Message}");
                return View("LogIn", model);
            }
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            try
            {
                var model = new ChangePasswordViewModel
                {
                    Username = User.Identity?.Name ?? ""
                };
                return View(model);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Change Password Failed To Get: {ex.Message}");
                return RedirectToAction("Index", "Account");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    User user = await userManager.FindByNameAsync(model.Username);
                    var result = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

                    if (result.Succeeded)
                    {
                        TempData["message"] = "Password changed successfully";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                return View(model);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Change Password Failed To Post: {ex.Message}");
                return View("ChangePassword", model);
            }
        }
    }
}
