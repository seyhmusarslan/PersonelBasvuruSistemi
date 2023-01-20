using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class RecruitmentDetailConditionConfiguration : IEntityTypeConfiguration<RecruitmentDetailCondition>
    {
        public void Configure(EntityTypeBuilder<RecruitmentDetailCondition> builder)
        {
            throw new NotImplementedException();
        }
    }
}
