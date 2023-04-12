using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class DocumentGroupConfiguration : IEntityTypeConfiguration<DocumentGroup>
    {
        public void Configure(EntityTypeBuilder<DocumentGroup> builder)
        {
            builder.Property(p => p.Name).IsRequired();

        }
    }
}
