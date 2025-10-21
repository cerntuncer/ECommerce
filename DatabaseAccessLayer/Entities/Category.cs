using ECommerce.DatabaseAccessLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.DatabaseAccessLayer.Models.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; } = null!;
        // Navigasyon Özelliği (Products tablosu ile Bire Çok ilişki)
        // Bir kategori birden çok ürüne sahip olabilir.
        public ICollection<Product> Products { get; set; } = new List<Product>();
    
    }
}
  