using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Models
{
    public class InstDepContext : IdentityDbContext<AppUser>
    {
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }

        public InstDepContext(){}
        public InstDepContext(DbContextOptions opt) : base(opt){ }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor>(b =>
            {
                b.HasKey(i => i.Id);

                b.Property(i => i.Name).HasMaxLength(30);
                b.Property(i => i.Address).HasMaxLength(50);
                b.Property(i => i.Salary).HasColumnType("money");

            });

            modelBuilder.Entity<Department>(b =>
            {
                b.HasKey(d => d.Id);

                b.Property(d => d.Name).HasMaxLength(30);
                b.Property(d => d.Location).HasMaxLength(50);
                b.Property(d => d.Description).HasMaxLength(100);

            });

            modelBuilder.Entity<Branch>(b =>
            {
                b.HasKey(b => b.Id);

                b.Property(i => i.Address).HasMaxLength(50);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
