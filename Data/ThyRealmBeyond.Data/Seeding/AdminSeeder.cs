namespace ThyRealmBeyond.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using ThyRealmBeyond.Common;
    using ThyRealmBeyond.Data.Models;

    internal class AdminSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext context, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();

            var roleManager = serviceProvider.GetService<RoleManager<ApplicationRole>>();

            var adminExists = await userManager
                .Users
                .AnyAsync(u => u.UserName == GlobalConstants.AdministratorUsername);

            if (!adminExists)
            {
                var admin = new ApplicationUser
                {
                    UserName = GlobalConstants.AdministratorUsername,
                    Email = GlobalConstants.AdministratorEmail,
                    EmailConfirmed = true,
                };

                var result = await userManager.CreateAsync(admin, GlobalConstants.AdministratorPassword);

                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }

                var roleExists = await roleManager.RoleExistsAsync(GlobalConstants.AdministratorRoleName);

                if (roleExists)
                {
                    await userManager.AddToRoleAsync(admin, GlobalConstants.AdministratorRoleName);
                }
            }
        }
    }
}
