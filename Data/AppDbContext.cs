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
           // modelBuilder.Entity<Order>().HasOne(o => o.Order).WithOne(oc => oc.Orders_Customers).HasForeignKey(oc => oc.OrderId);
            modelBuilder.Entity<Order>().HasOne(c => c.Customer).WithMany(oc => oc.Orders).HasForeignKey(oc => oc.Cust_Id);

            modelBuilder.Entity<Order>().Property(o => o.Amount).HasPrecision(10, 2);
            
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

    }
}
