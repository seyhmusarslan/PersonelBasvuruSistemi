using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class ApplicantExamConfiguration : IEntityTypeConfiguration<ApplicantExam>
    {
        public void Configure(EntityTypeBuilder<ApplicantExam> builder)
        {
            builder.Property(p=>p.ApplicantId).IsRequired();
            builder.Property(p=>p.ExamResult).IsRequired();
            builder.Property(p=>p.ExamName).IsRequired();
            builder.Property(p=>p.ExamYear).IsRequired();
            builder.Property(p=>p.Multiplier).IsRequired();
        }
    }
}
