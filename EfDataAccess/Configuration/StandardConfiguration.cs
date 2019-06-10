using DomainLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class StandardConfiguration : IEntityTypeConfiguration<Standard>
    {
        public void Configure(EntityTypeBuilder<Standard> builder)
        {
            builder.Property(s => s.StandardName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(s => s.Description)
                .IsRequired();

            builder.Property(s => s.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

        }
    }
}
