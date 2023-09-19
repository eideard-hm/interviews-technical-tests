using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Configs
{
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(p => p.Id);

            // define default values and data types
            builder
                .Property(p => p.Account)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.Password)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.Type)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(p => p.Status)
                .HasMaxLength(50)
                .HasDefaultValue("Activo");
        }
    }
}
