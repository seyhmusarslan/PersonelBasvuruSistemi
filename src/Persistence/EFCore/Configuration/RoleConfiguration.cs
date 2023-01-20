using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<RoleConfiguration>
    {
        public void Configure(EntityTypeBuilder<RoleConfiguration> builder)
        {
            throw new NotImplementedException();
        }
    }
}
