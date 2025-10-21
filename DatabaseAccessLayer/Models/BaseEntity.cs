using ECommerce.DatabaseAccessLayer.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations; // Gerekirse [Key] annotation'� burada tan�mlanabilir

namespace ECommerce.DatabaseAccessLayer.Models
{
    public abstract class BaseEntity
    {
        // MERKEZ�LE�T�R�LM�� PRIMARY KEY
        public int Id { get; set; } // int yerine long da kullanabilirsiniz (�rnek PersonId'deki gibi)

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
       
    }
}