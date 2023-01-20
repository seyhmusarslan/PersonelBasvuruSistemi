using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<UserConfiguration>
    {
        public void Configure(EntityTypeBuilder<UserConfiguration> builder)
        {
            throw new NotImplementedException();
        }
    }
}
