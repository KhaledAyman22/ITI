using Microsoft.EntityFrameworkCore;

namespace Task_2.Models
{
    public class StudentCourseContext:DbContext
    {

        public StudentCourseContext()
        {}

        public StudentCourseContext(DbContextOptions<StudentCourseContext> options)
        : base(options)
        {}

        public DbSet<Student> Students { get; set; }
        
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>(builder =>
            {
                builder.HasKey(s => s.Id);
                builder.Property(s => s.Name).HasMaxLength(20);
                builder.Property(s => s.Email).HasMaxLength(50);
            });

            modelBuilder.Entity<Course>(builder =>
            {
                builder.HasKey(s => s.Id);
                builder.Property(s => s.Topic).HasMaxLength(20);
            });
        }
    }
}
