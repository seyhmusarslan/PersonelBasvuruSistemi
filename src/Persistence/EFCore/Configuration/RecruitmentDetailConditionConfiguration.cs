using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class RecruitmentDetailConditionConfiguration : IEntityTypeConfiguration<RecruitmentDetailCondition>
    {
        public void Configure(EntityTypeBuilder<RecruitmentDetailCondition> builder)
        {
            builder.Property(p => p.RecruitmentDetailId).IsRequired();
            builder.Property(p => p.ConditionId).IsRequired();
        }
    }
}
