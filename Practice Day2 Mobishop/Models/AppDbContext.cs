
using Practice_Day2_Mobishop.Models;
using Microsoft.EntityFrameworkCore;

namespace Practice_Day2_Mobishop.Models

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }        
    }
}
