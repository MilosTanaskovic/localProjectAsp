using DomainLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class StudentAddressConfiguration : IEntityTypeConfiguration<StudentAddress>
    {
        public void Configure(EntityTypeBuilder<StudentAddress> builder)
        {
            builder.Property(sa => sa.Address)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(sa => sa.City)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(sa => sa.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            builder.HasIndex(sa => sa.StudentId)
                .IsUnique();
        }
    }
}
