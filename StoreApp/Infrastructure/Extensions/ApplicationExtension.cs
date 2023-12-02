using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories;

namespace StoreApp.Infrastructure.Extensions
{
    public static class ApplicationExtension
    {
        public static void ConfigureAndCheckMigration(this IApplicationBuilder app)
        {
            RepositoryContext context = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<RepositoryContext>();

            if(context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
        public static void ConfigureLocalization(this WebApplication app)
        {
            app.UseRequestLocalization(opt => 
            {
                opt.AddSupportedCultures("tr")
                .AddSupportedUICultures("tr")
                .SetDefaultCulture("tr");
            });
        }
        public static async void ConfigureDefaultAdminUserAsync(this IApplicationBuilder app)
        {
            const string adminUser = "Admin";
            const string password = "Admin+123456";

            // UserManager
            UserManager<IdentityUser> userManager =
            app.ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();

            // RoleManager
            RoleManager<IdentityRole> roleManager = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();
            IdentityUser? user = await userManager.FindByNameAsync(adminUser);
            if(user is null)
            {
                user = new IdentityUser()
                {
                    Email = "krmn@gmail.com",
                    PhoneNumber = "5351112233",
                    UserName = adminUser
                };
                var result = await userManager.CreateAsync(user, password);
                if(!result.Succeeded)
                {
                    throw new Exception("Admin user could not created.");
                }
                var roleResult = await userManager.AddToRolesAsync(user, roleManager.Roles.Select(x => x.Name).ToList());

                if(!roleResult.Succeeded)
                    throw new Exception("System have problems with role defination for Admin.");
            }
        }
    }
}