using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class ApplicantDocumentConfiguration : IEntityTypeConfiguration<ApplicantDocument>
    {
        public void Configure(EntityTypeBuilder<ApplicantDocument> builder)
        {
            builder.Property(p=>p.ApplicantId).IsRequired();
            builder.Property(p=>p.ApplicantId).IsRequired();
            builder.Property(p=>p.DocumentName).IsRequired();
            builder.Property(p=>p.DocumentPath).IsRequired();

        }
    }
}
