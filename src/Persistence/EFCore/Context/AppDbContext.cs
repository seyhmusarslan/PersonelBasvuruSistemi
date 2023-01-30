using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.EFCore.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Document> DocumentUsers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Recruitment> Recruitments { get; set; }
        public DbSet<RecruitmentDetail> RecruitmentDetails { get; set; }
        public DbSet<RecruitmentDetailApplicationDocument> RecruitmentDetailApplicationDocuments { get; set; }
        public DbSet<RecruitmentDetailCondition> RecruitmentDetailConditions { get; set; }
        public DbSet<RecruitmentDetailDocument> RecruitmentDetailDocuments { get; set; }
        public DbSet<RecruitmentType> RecruitmentTypes { get; set; }
    }
}
