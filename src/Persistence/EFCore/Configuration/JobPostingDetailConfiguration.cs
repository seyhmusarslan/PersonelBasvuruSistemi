using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class JobPostingDetailConfiguration : IEntityTypeConfiguration<JobPostingDetail>
    {
        public void Configure(EntityTypeBuilder<JobPostingDetail> builder)
        {
            builder.Property(p => p.Count).IsRequired();
            builder.Property(p => p.PositonId).IsRequired();
            builder.Property(p => p.WorkedDestination).IsRequired();
            builder.Property(p => p.Description).IsRequired();
        }
    }
}
