using Soka.Domain.Models.Entities.Membership;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Soka.Domain.Models.DataContexts
{
    public static class SokaDbContextSeedData
    {
        public static IApplicationBuilder SeedMembership(this IApplicationBuilder app)
        {
            return app;
            const string adminEmail = "elgunbayramov223@gmail.com";
            const string adminUserName = "elgunbayramov";   
            const string adminPassword = "123";
            const string roleName = "sa";

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<SokaDbContext>();
                db.Database.Migrate();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<SokaUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<SokaRole>>();

                var role = roleManager.FindByNameAsync(roleName).Result;

                if (role == null)
                {
                    role = new SokaRole
                    {
                        Name = roleName
                    };

                    roleManager.CreateAsync(role).Wait();
                }

                var user = userManager.FindByEmailAsync(adminEmail).Result;

                if (user == null)
                {
                    user = new SokaUser
                    {
                        Email = adminEmail,
                        UserName = adminUserName,
                        EmailConfirmed = true
                    };

                    userManager.CreateAsync(user, adminPassword).Wait();
                }

                if (userManager.IsInRoleAsync(user, roleName).Result == false)
                {
                    userManager.AddToRoleAsync(user, roleName).Wait();
                }
            }

            return app;
        }
    }
}
