using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class PositionSpecificDocumentConfiguration : IEntityTypeConfiguration<PositionSpecificDocument>
    {
        public void Configure(EntityTypeBuilder<PositionSpecificDocument> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.PositionId).IsRequired();
            builder.Property(p => p.IsRequired).IsRequired();
        }
    }
}
