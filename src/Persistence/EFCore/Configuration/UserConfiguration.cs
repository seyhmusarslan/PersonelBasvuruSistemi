using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p=>p.Address).IsRequired();
            builder.Property(p=>p.Firstname).IsRequired();
            builder.Property(p=>p.Lastname).IsRequired();
            builder.Property(p=>p.BirthDate).IsRequired();
            builder.Property(p=>p.Email).IsRequired();
            builder.Property(p=>p.IdentityNumber).IsRequired();
        }
    }
}
