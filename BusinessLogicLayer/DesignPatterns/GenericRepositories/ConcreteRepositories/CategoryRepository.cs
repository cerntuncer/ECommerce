using BusinessLogicLayer.DesignPatterns.GenericRepositories.BaseRepositories;
using BusinessLogicLayer.DesignPatterns.GenericRepositories.InterfaceRepositories;
using ECommerce.DatabaseAccessLayer.Contexts;
using ECommerce.DatabaseAccessLayer.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DesignPatterns.GenericRepositories.ConcreteRepositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        // BaseRepository, MyContext istiyor. CategoryRepository bu context'i alıp BaseRepository'ye vermelidir.
        public CategoryRepository(MyContext db) : base(db)
        {
        }
    }
}
