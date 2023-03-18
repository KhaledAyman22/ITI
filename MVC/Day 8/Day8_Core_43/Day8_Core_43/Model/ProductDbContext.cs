using Microsoft.EntityFrameworkCore;

namespace Day8_Core_43.Model
{
    public class ProductDbContext:DbContext
    {
        //request service of type DbContextOptions<ProductDbContext> 
        public ProductDbContext(DbContextOptions<ProductDbContext> options):base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; } 
    }
}
