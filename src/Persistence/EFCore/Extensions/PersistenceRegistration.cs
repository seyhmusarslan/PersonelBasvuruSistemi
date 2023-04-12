using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.EFCore.Context;

namespace Persistence.EFCore.Extensions
{
    public static class PersistenceRegistration
    {
        public static void AddPersistenceRegistration (this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options=>{
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
        }
    }
}
