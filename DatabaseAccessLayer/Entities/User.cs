using ECommerce.DatabaseAccessLayer.Models;
using ECommerce.DatabaseAccessLayer.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.DatabaseAccessLayer.Entities
{
    public class User : BaseEntity
    {
        // Ad ve Soyadı zorunlu değilse, null atanabilir (string?) bırakın.
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        [Required, MaxLength(100), EmailAddress]
        public string Email { get; set; } = null!; 

        [Required, MaxLength(256)]
        public string PasswordHash { get; set; } = null!; 

        [Required]
        public bool IsAdmin { get; set; } = false;

        // Navigasyon koleksiyonunu başlat
        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}