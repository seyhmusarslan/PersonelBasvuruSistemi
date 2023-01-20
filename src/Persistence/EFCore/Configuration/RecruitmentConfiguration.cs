using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class RecruitmentConfiguration : IEntityTypeConfiguration<Recruitment>
    {
        public void Configure(EntityTypeBuilder<Recruitment> builder)
        {
            throw new NotImplementedException();
        }
    }
}
