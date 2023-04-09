using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class APIDay02Context : DbContext
    {
        public DbSet<Developer> Developers => Set<Developer>();
        public DbSet<Ticket> Tickets => Set<Ticket>();
        public DbSet<Department> Departments => Set<Department>();

        public APIDay02Context(DbContextOptions<APIDay02Context> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var deps = JsonSerializer.Deserialize<List<Department>>("""[{"Id":1,"Name":"Department 1"},{"Id":2,"Name":"Department 2"}]""") ?? new();
            var tickets = JsonSerializer.Deserialize<List<Ticket>>("""[{"Id":1,"Name":"Ticket 1","DepartmentId":1},{"Id":2,"Name":"Ticket 2","DepartmentId":1},{"Id":3,"Name":"Ticket 3","DepartmentId":2}]""") ?? new();
            var devs = JsonSerializer.Deserialize<List<Developer>>("""[{"Id":1,"Name":"Developer 1"},{"Id":2,"Name":"Developer 2"}]""") ?? new();

            modelBuilder.Entity<Department>().HasData(deps);
            modelBuilder.Entity<Ticket>().HasData(tickets);
            modelBuilder.Entity<Developer>().HasData(devs);
        }
    }
}
