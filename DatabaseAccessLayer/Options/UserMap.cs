using ECommerce.DatabaseAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.DatabaseAccessLayer.Options
{
    public class UserMap : BaseMap<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder); // BaseMap ayarlarını uygula

            // E-posta'nın Benzersiz (Unique) olması çok önemlidir
            builder.HasIndex(u => u.Email)
                   .IsUnique();

            // Zorunluluk ve Uzunluk kısıtlamaları
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(256);

            // IsAdmin alanının zorunlu ve varsayılan değerinin FALSE olması
            builder.Property(u => u.IsAdmin).IsRequired().HasDefaultValue(false);

            // İlişki: User (One) -> Reviews (Many)
            builder.HasMany(u => u.Reviews)  // Bir kullanıcının çok yorumu var
                   .WithOne(r => r.User)     // Bir yorumun tek bir kullanıcısı var
                   .HasForeignKey(r => r.UserId) // Review tablosundaki FK
                   .OnDelete(DeleteBehavior.Restrict); // Kullanıcı silinirse yorumlar silinmesin (Kısıtla)
        }
    }
}