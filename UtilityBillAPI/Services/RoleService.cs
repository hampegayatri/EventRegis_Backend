// Services/RoleService.cs
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace EventManagementAPI.Services
{
    public class RoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RoleService(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task CreateRolesAsync()
        {
            string[] roleNames = { "Admin", "User" };
            IdentityResult roleResult;

            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    roleResult = await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            // Create an Admin user if not exists
            var adminUser = new IdentityUser
            {
                UserName = "admin@utilitybill.com",
                Email = "admin@utilitybill.com"
            };

            string adminPassword = "Admin@123";
            var admin = await _userManager.FindByEmailAsync(adminUser.Email);

            if (admin == null)
            {
                var createAdmin = await _userManager.CreateAsync(adminUser, adminPassword);
                if (createAdmin.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
