using ECommerce.DatabaseAccessLayer.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DatabaseAccessLayer.Options
{
    public class CategoryMap : BaseMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder); // BaseMap ayarlarını uygula

            // Kategori Adının Benzersiz Olması
            builder.HasIndex(c => c.Name)
                   .IsUnique();

            // İlişki: Category (One) -> Products (Many)
            builder.HasMany(c => c.Products) // Bir kategorinin çok ürünü var
                   .WithOne(p => p.Category) // Bir ürünün tek bir kategorisi var
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict); // Kategori silinirse ürünler silinmesin (Kısıtla)
        }
    }
}