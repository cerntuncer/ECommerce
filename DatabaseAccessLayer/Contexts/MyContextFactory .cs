using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ECommerce.DatabaseAccessLayer.Contexts;

namespace ECommerce.DatabaseAccessLayer
{
    public class MyContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=NLPCommerceDB;Trusted_Connection=True;TrustServerCertificate=True"
            );

            return new MyContext(optionsBuilder.Options);
        }
    }
}
