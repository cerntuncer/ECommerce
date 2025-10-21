using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using ECommerce.DatabaseAccessLayer.Entities;

namespace ECommerce.DatabaseAccessLayer.Models.Entities
{
    public class Review : BaseEntity
    {

        // Yabancı Anahtar Alanları
        public int ProductId { get; set; }
        public int UserId { get; set; }

        [Required]
        [Range(1, 5)] // Yıldızın 1 ile 5 arasında olmasını sağlar
        public int Rating { get; set; }

        [Required]
        [Column(TypeName = "ntext")] // SQL'deki ntext tipine karşılık gelir
        public string Content { get; set; } = null!;

        public DateTime ReviewDate { get; set; } = DateTime.Now;

        // NLP SONUÇLARI
        [Column(TypeName = "decimal(3, 2)")] // Örn: -1.00 ile 1.00 arası
        public decimal? NLPSentimentScore { get; set; } // NULL olabilir

        // AI KARARI
        public bool? IsRatingConsistent { get; set; } // NULL olabilir

        // Navigasyon Özellikleri (FK'ların karşılık geldiği Entity'ler)
        public Product Product { get; set; }
        public User User { get; set; }
    }
}