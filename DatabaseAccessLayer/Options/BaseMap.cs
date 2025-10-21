using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ECommerce.DatabaseAccessLayer.Models;

namespace ECommerce.DatabaseAccessLayer.Options
{
    // T, BaseEntity'den miras alan tüm sınıflar için genel konfigürasyonu sağlar
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            // Primary Key'i 'Id' olarak ayarla
            builder.HasKey(x => x.Id);

            // PK'nın otomatik artan (IDENTITY) olmasını ayarla
            builder.Property(x => x.Id)
                   .ValueGeneratedOnAdd();

            // CreatedDate zorunlu ve SQL'de varsayılan değerini GETDATE() olarak ayarla
            builder.Property(x => x.CreatedDate)
                   .IsRequired()
                   .HasDefaultValueSql("GETDATE()");

            // UpdatedDate opsiyonel
            builder.Property(x => x.UpdatedDate)
                   .IsRequired(false);
        }
    }
}