using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Models
{
    internal class CollegeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; Database = College1212; Integrated Security = true");
        }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
