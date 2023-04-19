using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class ApplicantStatuConfiguration: IEntityTypeConfiguration<ApplicantStatu>
    {
        public void Configure(EntityTypeBuilder<ApplicantStatu> builder)
        {
            builder.Property(p=>p.Name).IsRequired();
        }
    }
}
