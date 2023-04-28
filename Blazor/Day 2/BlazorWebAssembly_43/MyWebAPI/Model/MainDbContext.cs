using Microsoft.EntityFrameworkCore;
using SharedLibrary;

namespace MyWebAPI.Model
{
    public class MainDbContext:DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options):base(options)
        {
            
        }

        public virtual DbSet<Employee> Employees { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

    }
}
