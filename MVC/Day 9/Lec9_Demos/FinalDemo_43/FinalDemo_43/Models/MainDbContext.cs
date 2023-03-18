using Microsoft.EntityFrameworkCore;

namespace FinalDemo_43.Models
{
    public class MainDbContext:DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options):base(options)
        {
            
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Department> Departments { get; set; }

    }
}
