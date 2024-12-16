using Microsoft.AspNetCore.Identity;
namespace AirportTracker.Models
{
    public class ConfigureIdentity
    {
        public static async Task CreateAdminUserAsync(
        IServiceProvider provider)
        {
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = provider.GetRequiredService<UserManager<User>>();

            string username = "admin";
            string password = "Admin123!";
            string roleName = "Admin";
            string username2 = "AirportAdmin";
            string password2 = "Admin1234!";
            string roleName2 = "AirportAdmin";

            if (await roleManager.FindByNameAsync(roleName)==null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
            if (await roleManager.FindByNameAsync(roleName2) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName2));
            }
            if (await userManager.FindByNameAsync("JohnA") == null)
            {
                User user = new User
                {
                    UserName = "JohnA",
                    fName = "John",
                    lName = "Airport",
                    milage = 0
                };
                await userManager.CreateAsync(user, password);
            }

            if (await userManager.FindByNameAsync(username)==null)
            {
                User user = new User {
                    UserName = username,
                    fName = "Admin",
                    lName = "AdminLastName",
                    milage = 0
                };
                var result = await userManager.CreateAsync(user, password);

                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
                else
                {
                    Console.WriteLine(result.ToString());
                }
            }
            if (await userManager.FindByNameAsync(username2) == null)
            {
                User user = new User
                {
                    UserName = username2,
                    fName = "AirportAdmin",
                    lName = "AdminLastName2",
                    milage = 0
                };
                var result = await userManager.CreateAsync(user, password2);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName2);
                }
                else
                {
                    Console.WriteLine(result.ToString());
                }
            }
        }
    }
}
