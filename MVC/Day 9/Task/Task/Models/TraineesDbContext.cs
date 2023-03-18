using Microsoft.EntityFrameworkCore;

namespace FinalTask.Models
{
    public class TraineesDbContext:DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Trainee> Trainees { get; set; }

        public TraineesDbContext(DbContextOptions<TraineesDbContext> options):base(options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Track>(builder =>
            {
                builder.HasKey(t => t.Id);
                builder.Property(t => t.Name).HasMaxLength(50);
                builder.Property(t => t.Description).HasMaxLength(200);
            });

            modelBuilder.Entity<Course>(builder =>
            {
                builder.HasKey(c => c.Id);
                builder.Property(c => c.Topic).HasMaxLength(50);
                builder.Property(c => c.Grade).HasPrecision(2);
            });

            modelBuilder.Entity<Trainee>(builder =>
            {
                builder.HasKey  (t => t.Id);
                builder.Property(t => t.Name).HasMaxLength(50);
                builder.Property(t => t.Email).HasMaxLength(100);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
