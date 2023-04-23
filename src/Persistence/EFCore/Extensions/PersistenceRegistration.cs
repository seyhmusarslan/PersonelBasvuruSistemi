using System.Text;
using Application.Interfaces.Repositories;
using Application.Services.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Persistence.EFCore.Context;
using Persistence.EFCore.Models.Identity;
using Persistence.EFCore.Services;

namespace Persistence.EFCore.Extensions
{
    public static class PersistenceRegistration
    {
        public static void AddPersistenceServices (this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options=>{
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddIdentity<ApplicationUser,ApplicationRole>(options=>{
                options.Password.RequireDigit=false;
                options.Password.RequireLowercase=false;
                options.Password.RequiredLength=5;
                options.Password.RequireNonAlphanumeric=false;
                options.Password.RequireUppercase=false;

            }).AddEntityFrameworkStores<AppDbContext>()
              .AddDefaultTokenProviders();
            
            services.AddAuthentication(auth=>{
                auth.DefaultAuthenticateScheme=JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme=JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options=>{
                options.TokenValidationParameters= new Microsoft.IdentityModel.Tokens.TokenValidationParameters{
                    ValidateIssuer=true,
                    ValidateAudience=true,
                    ValidAudience=configuration["AuthSettings:Audience"],
                    ValidIssuer=configuration["AuthSettings:Audience"],
                    RequireExpirationTime=true,
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["AuthSettings:Key"])),
                    ValidateIssuerSigningKey=true 
                };
            });


            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IJwtTokenGeneratorService,JwtTokenGeneratorService>();

            services.AddScoped<IDocumentGroupRepositoryAsync,DocumentGroupRepositoryAsync>();
            services.AddScoped<IExamRepositoryAsync,ExamRepositoryAsync>();
            services.AddScoped<IPositionExamRepositoryAsync,PositionExamRepositoryAsync>();
            services.AddScoped<IPositionRepositoryAsync,PositionRepositoryAsync>();
            services.AddScoped<IPositionSpecificDocumentRepositoryAsync,PositionSpecificDocumentRepositoryAsync>();


            services.AddScoped<IApplicantDocumentRepositoryAsync,ApplicantDocumentRepositoryAsync>();
            services.AddScoped<IApplicantRepositoryAsync,ApplicantRepositoryAsync>();
            services.AddScoped<IApplicantExamRepositoryAsync,ApplicantExamRepositoryAsync>();
            services.AddScoped<IApplicantStatuRepositoryAsync,ApplicantStatuRepositoryAsync>();

            services.AddScoped<IJobPostingDetailRepositoryAsync,JobPostingDetailRepositoryAsync>();
            services.AddScoped<IJobTypeRepositoryAsync,JobTypeRepositoryAsync>();
            services.AddScoped<IJobPostingRepositoryAsync,JobPostingRepositoryAsync>();
            services.AddScoped<IJobTypeDocumentRepositoryAsync,JobTypeDocumentRepositoryAsync>();

        }
    }
}
