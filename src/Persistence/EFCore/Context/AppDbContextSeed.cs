using System;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence.EFCore.Models.Identity;

namespace Persistence.EFCore.Context
{
    public class AppDbContextSeed
    {
        
        public static async Task SeedAsync(AppDbContext context,UserManager<ApplicationUser> _userManager,RoleManager<ApplicationRole> _roleManager,int retry=0)
        {
            int retryForAvaibility = retry;
            try
            {
                context.Database.Migrate();
                if(!context.Roles.Any())
                {
                    await GetPreConfiguredRolesAsync(_roleManager);
                }
                if (!context.Users.Any())
                {
                    await GetPreConfiguredUsersAsync(_userManager);
                }
                if(!context.JobTypes.Any())
                {
                    await GetPreConfiguredJobTypesAsync(context);
                }
            }
            catch (Exception)
            {
                if (retryForAvaibility<10)
                {
                    retryForAvaibility++;
                    await SeedAsync(context, _userManager, _roleManager,retryForAvaibility);
                }
            }
        }

        private static Task GetPreConfiguredJobTypesAsync(AppDbContext context)
        {
            context.JobTypes.AddRange(new List<JobType>
            {
                new JobType
                {
                    Name = "Sözleşmeli Personel"
                },
                new JobType
                {
                    Name = "Öğretim Elemanı"
                },
                new JobType
                {
                    Name = "Öğretim Görevlisi"
                }
            });
            return context.SaveChangesAsync();
        }

        private static async Task GetPreConfiguredRolesAsync(RoleManager<ApplicationRole> _roleManager)
        {
            await _roleManager.CreateAsync(new ApplicationRole { Name = "Admin" });
            await _roleManager.CreateAsync(new ApplicationRole { Name = "User" });
        }

        private static async Task GetPreConfiguredUsersAsync(UserManager<ApplicationUser> _userManager)
        {
            //create user
            var user = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@localhost",
                EmailConfirmed = true,
                Name = "Admin",
                Surname = "Admin",
                PhoneNumber = "123456789",
                PhoneNumberConfirmed = true
            };
            //create password
            string password = "Admin123.";
            //create user
            await _userManager.CreateAsync(user,password);
            await _userManager.AddToRoleAsync(user,"Admin");

        }
    }
}
