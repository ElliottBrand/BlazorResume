using BlazorResume.Server.Models;
using Microsoft.AspNetCore.Identity;
using System;

namespace BlazorResume.Server.Data
{
    public static class SeedUsers
    {
        public static void Initialize(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            SeedRole(roleManager);
            SeedUser(userManager);
        }

        private static void SeedRole(RoleManager<IdentityRole> roleManager)
        {
            if (roleManager.FindByNameAsync("administrator").Result == null)
            {
                IdentityRole role = new IdentityRole() { Name = "administrator" };
                roleManager.CreateAsync(role).Wait();
            }
            if (roleManager.FindByNameAsync("user").Result == null)
            {
                IdentityRole role = new IdentityRole() { Name = "user" };
                roleManager.CreateAsync(role).Wait();
            }
        }

        private static void SeedUser(UserManager<ApplicationUser> userManager)
        {
            string adminName = "admin@domain.com";
                string pwd = "Password123!";
            string roleName = "administrator";
            if (userManager.FindByNameAsync(adminName).Result == null)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = adminName,
                    Email = adminName,
                    EmailConfirmed = true
                };
                userManager.CreateAsync(user, pwd).Wait();

                if (userManager.FindByNameAsync(adminName).Result != null)
                {
                    userManager.AddToRoleAsync(user, roleName).Wait();
                }
            }
        }
    }
}
