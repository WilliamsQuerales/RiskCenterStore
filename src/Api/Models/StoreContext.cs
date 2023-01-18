using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace RiskCenterStoreApi.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options) {
        
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}
