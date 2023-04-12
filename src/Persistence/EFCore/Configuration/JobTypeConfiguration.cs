using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class JobTypeConfiguration : IEntityTypeConfiguration<JobType>
    {
        public void Configure(EntityTypeBuilder<JobType> builder)
        {
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
