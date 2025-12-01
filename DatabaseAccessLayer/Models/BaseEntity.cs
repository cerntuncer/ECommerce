using DatabaseAccessLayer.Enumerations;
using ECommerce.DatabaseAccessLayer.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations; // Gerekirse [Key] annotation'ý burada tanýmlanabilir

namespace ECommerce.DatabaseAccessLayer.Models
{
    public abstract class BaseEntity
    {
        // MERKEZÝLEÞTÝRÝLMÝÞ PRIMARY KEY
        public int Id { get; set; } // int yerine long da kullanabilirsiniz (örnek PersonId'deki gibi)

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        // SOFT DELETE ÝÇÝN EKLENEN ALAN
        public Status Status { get; set; } = Status.Active;

    }
}