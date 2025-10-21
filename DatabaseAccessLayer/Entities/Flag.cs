using ECommerce.DatabaseAccessLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.DatabaseAccessLayer.Models.Entities
{
    public class Flag : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        [MaxLength(200)]
        public string Description { get; set; } = null!;
        // Navigasyon Özelliği (Products tablosu ile Bire Çok ilişki)
        // Bir Bayrak birden çok ürüne atanabilir.
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
