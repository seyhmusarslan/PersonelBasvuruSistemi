using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class JobPostingConfiguration : IEntityTypeConfiguration<JobPosting>
    {
        public void Configure(EntityTypeBuilder<JobPosting> builder)
        {
            builder.Property(p=>p.Title).IsRequired();
            builder.Property(p=>p.StartDate).IsRequired();
            builder.Property(p=>p.EndDate).IsRequired();
            builder.Property(p=>p.JobTypeId).IsRequired();
            builder.Property(p=>p.IsActive).IsRequired();
        }
    }
}
