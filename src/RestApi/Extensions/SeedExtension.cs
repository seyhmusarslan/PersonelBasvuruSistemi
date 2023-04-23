using System;
using Microsoft.AspNetCore.Identity;
using Persistence.EFCore.Context;
using Persistence.EFCore.Models.Identity;

namespace RestApi.Extensions
{
    public static class SeedExtension
    {
        public static IApplicationBuilder UseSeed(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var context = scope.ServiceProvider.GetService<AppDbContext>();
                var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetService<RoleManager<ApplicationRole>>();
                AppDbContextSeed.SeedAsync(context, userManager, roleManager).Wait();
            }
            return app;
        }
    }
}
