using Microsoft.EntityFrameworkCore;
using ECommerce.DatabaseAccessLayer.Contexts;


namespace BusinessLogicLayer.SingletonPattern
{
    public class DbTool
    {
        private static MyContext _context;

        public static MyContext GetInstance()
        {
            if (_context == null)
            {
                var optionsBuilder = new DbContextOptionsBuilder<MyContext>();
                optionsBuilder.UseSqlServer("Server=.;Database=ECommerceDB;Trusted_Connection=True;");
                _context = new MyContext(optionsBuilder.Options);
            }

            return _context;
        }
    }
}
