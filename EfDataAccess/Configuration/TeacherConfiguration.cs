using DomainLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.Property(t => t.TFirstName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(t => t.TLastName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(t => t.Nationality)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(t => t.Description)
                .IsRequired();

            builder.Property(t => t.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
                
              

        }
    }
}
