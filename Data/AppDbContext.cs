using AcademyAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace AcademyAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 
        }

        public DbSet<Order> Orders { get; set; }
    }
}
