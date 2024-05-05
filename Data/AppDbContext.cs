using AcademyAPI.Model;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

namespace AcademyAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order_Customer>().HasKey(oc => new
            {
                //jjj
                oc.OrderId,
                oc.CustomerId
            });

            modelBuilder.Entity<Order_Customer>().HasOne(o => o.Order).WithMany(oc => oc.Orders_Customers).HasForeignKey(oc => oc.OrderId);
            modelBuilder.Entity<Order_Customer>().HasOne(c => c.Customer).WithMany(oc => oc.Orders_Customers).HasForeignKey(oc => oc.CustomerId);
            
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Order_Customer> Orders_Customers { get; set; }
    }
}
