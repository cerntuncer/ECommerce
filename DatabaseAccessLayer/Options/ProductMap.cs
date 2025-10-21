using ECommerce.DatabaseAccessLayer.Entities;
using ECommerce.DatabaseAccessLayer.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DatabaseAccessLayer.Options
{
    public class ProductMap : BaseMap<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder); // BaseMap ayarlarını uygula

            // Veri Tiplerini Belirleme
            builder.Property(p => p.Description)
                   .HasColumnType("NVARCHAR(MAX)");


            builder.Property(p => p.Price)
                   .HasColumnType("decimal(10, 2)");

            builder.Property(p => p.AverageRating)
                   .HasColumnType("decimal(2, 1)");

            // İlişki: Product (One) -> Reviews (Many)
            builder.HasMany(p => p.Reviews) // Bir ürünün çok yorumu var
                   .WithOne(r => r.Product) // Bir yorumun tek bir ürünü var
                   .HasForeignKey(r => r.ProductId)
                   .OnDelete(DeleteBehavior.Cascade); // Ürün silinirse yorumlar da silinsin
        }
    }
}