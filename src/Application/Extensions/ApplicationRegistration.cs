using System.Reflection;
using System;
using Application.Mappings;
using Application.Services.JobPostings;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class ApplicationRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assembly =Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddScoped<IJobPostingService, JobPostingService>();
        }
    }
}
