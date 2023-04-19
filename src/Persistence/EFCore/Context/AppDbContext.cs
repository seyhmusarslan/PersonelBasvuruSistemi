using Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Persistence.EFCore.Models.Identity;
using System.Reflection;

namespace Persistence.EFCore.Context
{
    public class AppDbContext:IdentityDbContext<ApplicationUser,ApplicationRole,string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<DocumentGroup> DocumentGroups { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }
        public DbSet<JobPostingDetail> JobPostingDetails { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<JobTypeDocument> JobTypeDocuments { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionExam> PositionExams { get; set; }
        public DbSet<PositionSpecificDocument> PositionSpecificDocuments { get; set; }
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<ApplicantDocument> ApplicantDocuments { get; set; }
        public DbSet<ApplicantExam> ApplicantExams { get; set; }
        public DbSet<ApplicantStatu> ApplicantStatus { get; set; }
    }
}
