using BusinessLogicLayer.DesignPatterns.GenericRepositories.BaseRepositories;
using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using ECommerce.DatabaseAccessLayer.Contexts;
using ECommerce.DatabaseAccessLayer.Entities;

namespace BusinessLogicLayer.DesignPatterns.GenericRepositories.ConcreteRepositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(MyContext db) : base(db)
        {
        }
    }
}