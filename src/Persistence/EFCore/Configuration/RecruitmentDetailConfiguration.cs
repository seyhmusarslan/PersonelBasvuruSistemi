using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class RecruitmentDetailConfiguration : IEntityTypeConfiguration<RecruitmentDetail>
    {
        public void Configure(EntityTypeBuilder<RecruitmentDetail> builder)
        {
            builder.Property(p=>p.Unit).IsRequired();
            builder.Property(p=>p.RecruitmentId).IsRequired();
            builder.Property(p=>p.Count).IsRequired();
            builder.Property(p=>p.PositionId).IsRequired();
        }
    }
}
