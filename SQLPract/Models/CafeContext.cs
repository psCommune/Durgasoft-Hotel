using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLPract.Models
{
    internal class CafeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = Cafe1212;Integrated Security = true");
        }
        public DbSet<Cafe> Cafe { get; set; }
        public DbSet<CafeType> cafeTypes { get; set; }
        public DbSet<Review> reviews { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
