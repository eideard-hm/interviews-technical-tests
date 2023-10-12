using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Configs
{
    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            // define default values and data types
            builder
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(p => p.Description)
                .HasMaxLength(100);

            builder
                .Property(p => p.Price)
                .IsRequired();

            builder
                .Property(p => p.Stock)
                .IsRequired();

            builder
                .Property(p => p.ImageUrl)
                .HasMaxLength(500)
                .IsRequired();

            // define relationship between tables
            builder
                .HasMany(p => p.UserProductDetails)
                .WithOne(detail => detail.Product);
        }
    }
}
