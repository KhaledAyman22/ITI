using Microsoft.EntityFrameworkCore;
using Task_Day01.Models;

namespace Task_Day01
{
    public class MyDbContext : DbContext
    {
        public DbSet<Product> Products => Set<Product>();
        public DbSet<Comment> Comments => Set<Comment>();

        public MyDbContext(DbContextOptions opt):base(opt)
        {
            
        }
    }
}
