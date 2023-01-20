using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class ApplicationFileConfiguration : IEntityTypeConfiguration<ApplicationFile>
    {
        public void Configure(EntityTypeBuilder<ApplicationFile> builder)
        {
            throw new NotImplementedException();
        }
    }
}
