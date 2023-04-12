using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class PositionExamConfiguration : IEntityTypeConfiguration<PositionExam>
    {
        public void Configure(EntityTypeBuilder<PositionExam> builder)
        {
            builder.Property(p => p.MinResult).IsRequired();
            builder.Property(p => p.Multiplier).IsRequired();
            builder.Property(p => p.PositionId).IsRequired();
        }
    }
}
