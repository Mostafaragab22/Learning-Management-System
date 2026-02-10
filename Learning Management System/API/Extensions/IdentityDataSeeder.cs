using Learning_Management_System.Core.Entities;
using Microsoft.AspNetCore.Identity;

public static class IdentityDataSeeder
{
    public static async Task SeedRolesAsync(RoleManager<Role> roleManager)
    {
        string[] roles = { "Admin", "Student", "Instructor" };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new Role
                {
                    Name = role
                });
            }
        }
    }
}
