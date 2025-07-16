using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using ProductOrderManagement.Models;

namespace ProductOrderManagement.Data;

public static class DbSeeder
{
    public static async Task SeedRolesAndSuperAdminAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        //Seed roles
        string[] roles = ["Admin", "User"];
        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
        }

        // Seed SuperAdmin user
        string superAdminEmail = "superadmin@example.com";
        string superAdminPassword = "Password@123";

        var superAdminUser = await userManager.FindByEmailAsync(superAdminEmail);
        if (superAdminUser == null)
        {
            superAdminUser = new ApplicationUser
            {
                UserName = superAdminEmail,
                Email = superAdminEmail,
                EmailConfirmed = true
            };

            var createResult = await userManager.CreateAsync(superAdminUser, superAdminPassword);
            if (createResult.Succeeded)
            {
                await userManager.AddToRoleAsync(superAdminUser, "Admin");
            }
            else
            {
                throw new Exception($"Failed to create SuperAdmin user: {string.Join(", ", createResult.Errors.Select(e => e.Description))}");
            }
        }
    }
}
