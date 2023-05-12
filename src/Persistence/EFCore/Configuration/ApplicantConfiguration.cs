using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
    {
        public void Configure(EntityTypeBuilder<Applicant> builder)
        {
            builder.Property(p=>p.ApplicantStatuId).IsRequired();
            builder.Property(p=>p.JobPostingId).IsRequired();
            builder.Property(p=>p.UserId).IsRequired();
        }
    }
}
