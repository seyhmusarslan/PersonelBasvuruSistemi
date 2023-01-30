﻿using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EFCore.Configuration
{
    public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
    {
        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.RecruitmentDetailId).IsRequired();
            builder.Property(p => p.RecruitmentId).IsRequired();
        }
    }
}
