using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class RecruitmentTypeConfiguration : IEntityTypeConfiguration<RecruitmentType>
    {
        public void Configure(EntityTypeBuilder<RecruitmentType> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p => p.Active).IsRequired();
        }
    }
}
