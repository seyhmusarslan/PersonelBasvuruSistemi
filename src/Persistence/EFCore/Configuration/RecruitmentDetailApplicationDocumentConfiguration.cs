using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class RecruitmentDetailApplicationDocumentConfiguration : IEntityTypeConfiguration<RecruitmentDetailApplicationDocument>
    {
        public void Configure(EntityTypeBuilder<RecruitmentDetailApplicationDocument> builder)
        {
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.RecruitmentDetailId).IsRequired();
            builder.Property(p => p.ApplicationId).IsRequired();
            builder.Property(p => p.DocumentId).IsRequired();
            builder.Property(p => p.RecruitmentId).IsRequired();
        }
    }
}
