using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFW.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFW
{
    public class TeamsRegistrationDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        public DbSet<Game> Games { get; set; }

        public TeamsRegistrationDbContext()
        {
            
        }

        public void DeleteDbContext()
        {
            Console.WriteLine("Delete DB");
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=TeamRegistrationApp.db");
        }
    }
}
