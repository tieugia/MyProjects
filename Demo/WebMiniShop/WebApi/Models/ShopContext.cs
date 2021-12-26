using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class ShopContext : DbContext
    {
        public ShopContext(DbContextOptions options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
    }
}
