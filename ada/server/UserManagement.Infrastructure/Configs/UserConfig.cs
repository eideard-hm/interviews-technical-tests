using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Application.Enums;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Configs
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            builder
                 .HasIndex(b => b.IdentificationNumber)
                 .IsUnique();

            // define default values and data types
            builder
                .Property(p => p.Address)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(200);

            builder
                .Property(p => p.UserName)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(p => p.IdentificationNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .Property(p => p.FullName)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.Phone)
                .HasMaxLength(10);

            builder
                .Property(p => p.UserProfile)
                .HasDefaultValue(UserProfiles.SHOPPING);
        }
    }
}
