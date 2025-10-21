using ECommerce.DatabaseAccessLayer.Entities;
using ECommerce.DatabaseAccessLayer.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ECommerce.DatabaseAccessLayer.Contexts
{
    // DbContext'ten miras alır ve projemizin veri tabanı oturumunu temsil eder
    public class MyContext : DbContext
    {
        // Constructor: Bağlantı seçeneklerini (ConnectionString) dışarıdan alır.
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }

        // DbSets: Veri tabanındaki her bir tabloya karşılık gelen koleksiyonlar
        public DbSet<User> Users { get; set; } = null!; // null! ataması, CS8618'i önler
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Review> Reviews { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Flag> Flags { get; set; } = null!;

        // OnModelCreating: Fluent API konfigürasyonlarını uyguladığımız yer
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Bu satır, Options klasörünüzdeki IEntityTypeConfiguration arayüzünü uygulayan 
            // (yani tüm Map sınıflarınızı) otomatik olarak bulur ve uygular.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }
    }
}