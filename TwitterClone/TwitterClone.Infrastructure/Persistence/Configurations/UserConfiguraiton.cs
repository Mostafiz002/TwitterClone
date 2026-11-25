using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Persistence.Configurations
{
    public class UserConfiguraiton : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(256).IsRequired();
            builder.Property(u => u.PhoneNumber).HasMaxLength(20);
            builder.Property(u => u.PasswordHash).IsRequired();

            builder.HasIndex(u => u.Email).IsUnique();

        }
    }
}
