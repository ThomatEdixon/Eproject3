using eProject3.Model;
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
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasIndex(c => new { c.Cus_email }).IsUnique(true);
        }

        public DbConnection(DbContextOptions options):base(options)
        {
            
        }
    }
}
