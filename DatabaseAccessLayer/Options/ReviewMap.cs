using ECommerce.DatabaseAccessLayer.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DatabaseAccessLayer.Options
{
    public class ReviewMap : BaseMap<Review>
    {
        public override void Configure(EntityTypeBuilder<Review> builder)
        {
            base.Configure(builder); // BaseMap ayarlarını uygula

            // Veri Tiplerini Belirleme
            builder.Property(r => r.Content)
                   .HasColumnType("NVARCHAR(MAX)"); // Yorum metni uzun olabilir

            // NLP alanları NULL olabilir
            builder.Property(r => r.NLPSentimentScore)
                   .HasColumnType("decimal(3, 2)")
                   .IsRequired(false);

            builder.Property(r => r.IsRatingConsistent)
                   .IsRequired(false);

            // İlişkiler: (Zaten ProductMap ve UserMap'te tanımlandı, burada sadeleştirebiliriz)

            // Review (Many) -> User (One)
            builder.HasOne(r => r.User)
                   .WithMany(u => u.Reviews)
                   .HasForeignKey(r => r.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Review (Many) -> Product (One)
            builder.HasOne(r => r.Product)
                   .WithMany(p => p.Reviews)
                   .HasForeignKey(r => r.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}