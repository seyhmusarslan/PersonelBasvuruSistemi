using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class ExamConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.Property(p=>p.Name).IsRequired();
        }
    }
}
