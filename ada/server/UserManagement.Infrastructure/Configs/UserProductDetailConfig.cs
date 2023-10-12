using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.Configs
{
    internal class UserProductDetailConfig : IEntityTypeConfiguration<UserProductDetail>
    {
        public void Configure(EntityTypeBuilder<UserProductDetail> builder)
        {
            builder.HasKey(p => new { p.ProductId, p.UserId });

            // define default values and data types
            builder
                .Property(p => p.UnitPrice)
                .IsRequired();

            builder
                .Property(p => p.QuantitySold)
                .IsRequired();

            builder
                .Property(p => p.Total)
                .IsRequired();

            builder
                .HasOne(product => product.Product)
                .WithMany(detail => detail.UserProductDetails);

            builder
                .HasOne(invoice => invoice.User)
                .WithMany(detail => detail.UserProductDetails);
        }
    }
}
