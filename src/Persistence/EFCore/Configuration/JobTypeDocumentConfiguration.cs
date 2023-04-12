using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class JobTypeDocumentConfiguration : IEntityTypeConfiguration<JobTypeDocument>
    {
        public void Configure(EntityTypeBuilder<JobTypeDocument> builder)
        {
            builder.Property(p => p.DocumentGroupId).IsRequired();
            builder.Property(p => p.IsRequired).IsRequired();
            builder.Property(p => p.JobTypeId).IsRequired();
            builder.Property(p => p.Name).IsRequired();
        }
    }
}
