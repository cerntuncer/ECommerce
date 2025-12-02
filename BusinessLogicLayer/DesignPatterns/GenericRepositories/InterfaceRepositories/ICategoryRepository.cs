using ECommerce.DatabaseAccessLayer.Entities;
using ECommerce.DatabaseAccessLayer.Models.Entities;

namespace BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories
{
    // Class yerine Interface olmalı
    public interface ICategoryRepository : IRepository<Category>
    {
        // Category'e özgü metotlar buraya gelir.
    }
}