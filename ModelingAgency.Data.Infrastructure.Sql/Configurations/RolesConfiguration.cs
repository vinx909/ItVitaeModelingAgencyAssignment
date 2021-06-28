using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelingAgency.Data.Service.Infrastructure.Sql.Configurations
{
    public class RolesConfiguration
    {
        private readonly ModelingAgencyContext context;

        public RolesConfiguration(ModelingAgencyContext context)
        {
            this.context = context;
        }
        public async Task CreateRoles(IServiceProvider serviceProvider)
        {
            var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var UserManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
            string[] roleNames = { "Admin", "Client", "Model" };

            foreach (var roleName in roleNames)
            {
                if (!context.Roles.Any(r => r.Name == roleName))
                {
                    await RoleManager.CreateAsync(new IdentityRole { Name = roleName, NormalizedName = roleName.ToLower() });
                }
            }

            var adminUser = new IdentityUser
            {
                UserName = "Administrator",
                Email = "Admin@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = false
            };

            if(!context.Users.Any(u => u.UserName == adminUser.UserName))
            {
                var password = new PasswordHasher<IdentityUser>();
                var hashed = password.HashPassword(adminUser, "Wachtwoord456!");
                adminUser.PasswordHash = hashed;

                await UserManager.CreateAsync(adminUser);
                await UserManager.AddToRoleAsync(adminUser, "admin");
            }

            await context.SaveChangesAsync();
        }
    }
}
