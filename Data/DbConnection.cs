using Microsoft.EntityFrameworkCore;
using ServiceMarketingSystem.Models;

namespace ServiceMarketingSystem.Data
{
    public class DbConnection : DbContext
    {
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<Slug> Slug { get; set; }
        public DbSet<Stores> Stores { get; set; }

        public DbConnection(DbContextOptions options):base(options)
        {
            
        }
    }
}
