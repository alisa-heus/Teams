using ClientOrdersFW.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientOrdersFW
{
    internal class ClientOrdersDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public ClientOrdersDbContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=ITEAClientOrdersApp.db");
        }
    }
}
