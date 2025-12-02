using BusinessLogicLayer.DesignPatterns.GenericRepositories.BaseRepositories;
using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using ECommerce.DatabaseAccessLayer.Contexts;
using ECommerce.DatabaseAccessLayer.Entities;
using ECommerce.DatabaseAccessLayer.Models.Entities;

namespace BusinessLogicLayer.DesignPatterns.GenericRepositories.ConcreteRepositories
{
    public class FlagRepository : BaseRepository<Flag>, IFlagRepository
    {
        public FlagRepository(MyContext db) : base(db)
        {
        }
    }
}