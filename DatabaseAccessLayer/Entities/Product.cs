using ECommerce.DatabaseAccessLayer.Models;
using ECommerce.DatabaseAccessLayer.Models.Entities;

namespace ECommerce.DatabaseAccessLayer.Entities
{
    public class Product : BaseEntity
    {
        // ... (Id BaseEntity'den geliyor) ...

        public string Name { get; set; } = null!; 

        // Satır 11: Düzeltme
        public string Description { get; set; } = null!;

        // Satır 18: Düzeltme
        public string ImageURL { get; set; } = null!;

        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        public decimal AverageRating { get; set; } = 0.0m;

        // Yabancı Anahtar Alanları (FK'lar)
        public int CategoryId { get; set; }
        public int? FlagId { get; set; }

        // Navigasyon Özellikleri: Navigation Property'ler de zorunludur.

        // Satır 30: Düzeltme
        public Category Category { get; set; } = null!;

        // Satır 43: Düzeltme
        public Flag Flag { get; set; } = null!;

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}