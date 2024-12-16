using AirportTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Threading.Tasks;

namespace AirportTracker.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public RoleController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task CheckUserRolesAsync()
        {
            foreach (User user in userManager.Users)
            {
                foreach (IdentityRole role in roleManager.Roles)
                {
                    if (await userManager.IsInRoleAsync(user, role.Name))
                    {
 
                    }
                }
            }
        }

        public async Task CreateAdmin()
        {
            var result = await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (result.Succeeded) {}
        }

        public async Task CreateEmployee()
        {
            var result = await roleManager.CreateAsync(new IdentityRole("Employee"));
            if (result.Succeeded) {}
        }
    }
}
