using ClassLibrary;
using Microsoft.EntityFrameworkCore;

namespace Backend
{
    public class MyDbContext : DbContext
    {
        public DbSet<Track> Tracks => Set<Track>();
        public DbSet<Trainee> Trainees => Set<Trainee>();

        public MyDbContext(DbContextOptions opt) : base(opt)
        {

        }
    }
}
