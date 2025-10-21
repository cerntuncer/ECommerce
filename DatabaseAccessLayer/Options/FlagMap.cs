using ECommerce.DatabaseAccessLayer.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ECommerce.DatabaseAccessLayer.Options
{
    public class FlagMap : BaseMap<Flag>
    {
        public override void Configure(EntityTypeBuilder<Flag> builder)
        {
            base.Configure(builder);

            // Flag Adının Benzersiz Olması
            builder.HasIndex(f => f.Name)
                   .IsUnique();

            // İlişki: Flag (One) -> Products (Many)

            builder.HasMany(f => f.Products)
                   .WithOne(p => p.Flag)
                   .HasForeignKey(p => p.FlagId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Restrict);

            // BAŞLANGIÇ VERİSİ (SEED DATA)
            builder.HasData(
                new Flag
                {
                    Id = 1,
                    Name = "Yeşil Bayrak",
                    Description = "Tutarlı ve Güvenilir Yorumlar"
                    // CreatedDate DB tarafında GETDATE() ile otomatik atanacak
                },
                new Flag
                {
                    Id = 2,
                    Name = "Kırmızı Bayrak",
                    Description = "Tutarsız veya Şüpheli Yorumlar"
                }
            );
        }
    }
}
