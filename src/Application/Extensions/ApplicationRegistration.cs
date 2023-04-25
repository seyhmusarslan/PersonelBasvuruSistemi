using System.Reflection;
using System;
using Application.Mappings;
using Application.Services.JobPostings;
using Microsoft.Extensions.DependencyInjection;
using Application.Services.JobTypes;

namespace Application.Extensions
{
    public static class ApplicationRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assembly =Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assembly);
            services.AddScoped<IJobPostingService, JobPostingService>();
            services.AddScoped<IJobTypeService, JobTypeService>();
        }
    }
}
