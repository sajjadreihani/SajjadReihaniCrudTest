using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistences.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(p => p.LastName)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(p => p.Email)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(p => p.BankAccountNumber)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .HasColumnType("varchar(15)")
                .IsRequired();


            builder.HasIndex(p => p.Email).IsUnique();

            builder.HasIndex(p => new { p.FirstName, p.LastName, p.DateOfBirth }).IsUnique();

        }
    }
}
