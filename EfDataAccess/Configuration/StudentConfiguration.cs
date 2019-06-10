using DomainLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configuration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(std => std.StudentName)
                .HasMaxLength(30)
                .IsRequired();
            builder.Property(std => std.Natioanality)
                .HasMaxLength(40)
                .IsRequired();

            builder.Property(std => std.CreatedAt)
                .HasDefaultValueSql("GETDATE()");


            builder.HasMany(std => std.StudentCourses)
                .WithOne(sc => sc.Student)
                .HasForeignKey(sc => sc.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
                
        }
    }
}
