using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HotelContext:DbContext
    {
        public virtual DbSet<Reservation> Reservations { get; set; }

        public virtual DbSet<Kitchen> Kitchens { get; set; }
        
        public virtual DbSet<Frontend> Frontends { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=KHALED;Initial Catalog=HotelManagmentSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kitchen>(builder =>
            {
                builder.HasKey(k => k.Username);
                builder.Property(k => k.Username).HasMaxLength(50);
                builder.Property(k => k.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Frontend>(builder =>
            {
                builder.HasKey(k => k.Username);
                builder.Property(k => k.Username).HasMaxLength(50);
                builder.Property(k => k.Password).HasMaxLength(50);
            });

            modelBuilder.Entity<Reservation>(builder =>
            {
                builder.HasKey(r => r.Id);

                builder.Property(r => r.Id).HasColumnType("int");
                builder.Property(r => r.FirstName).HasColumnType("nvarchar(50)");
                builder.Property(r => r.LastName).HasColumnType("nvarchar(50)");
                builder.Property(r => r.BirthDay).HasColumnType("nvarchar(50)");
                builder.Property(r => r.Gender).HasColumnType("nvarchar(50)");
                builder.Property(r => r.PhoneNumber).HasColumnType("nvarchar(50)");
                builder.Property(r => r.EmailAddress).HasColumnType("nvarchar(MAX)");
                builder.Property(r => r.NumberGuest).HasColumnType("int");
                builder.Property(r => r.StreetAddress).HasColumnType("nvarchar(MAX)");
                builder.Property(r => r.AptSuite).HasColumnType("nvarchar(50)");
                builder.Property(r => r.City).HasColumnType("nvarchar(MAX)");
                builder.Property(r => r.State).HasColumnType("nvarchar(50)");
                builder.Property(r => r.ZipCode).HasColumnType("nchar(10)");
                builder.Property(r => r.RoomType).HasColumnType("nchar(10)");
                builder.Property(r => r.RoomFloor).HasColumnType("nchar(10)");
                builder.Property(r => r.RoomNumber).HasColumnType("nchar(10)");
                builder.Property(r => r.TotalBill).HasColumnType("float");
                builder.Property(r => r.PaymentType).HasColumnType("nchar(10)");
                builder.Property(r => r.CardType).HasColumnType("nchar(10)");
                builder.Property(r => r.CardNumber).HasColumnType("nvarchar(50)");
                builder.Property(r => r.CardExp).HasColumnType("nvarchar(50)");
                builder.Property(r => r.CardCvc).HasColumnType("nchar(10)");
                builder.Property(r => r.ArrivalTime).HasColumnType("date");
                builder.Property(r => r.LeavingTime).HasColumnType("date");
                builder.Property(r => r.CheckIn).HasColumnType("bit");
                builder.Property(r => r.BreakFast).HasColumnType("int");
                builder.Property(r => r.Lunch).HasColumnType("int");
                builder.Property(r => r.Dinner).HasColumnType("int");
                builder.Property(r => r.Cleaning).HasColumnType("bit");
                builder.Property(r => r.Towel).HasColumnType("bit");
                builder.Property(r => r.SSurprise).HasColumnType("bit");
                builder.Property(r => r.SupplyStatus).HasColumnType("bit");
                builder.Property(r => r.FoodBill).HasColumnType("int");
            });
        }
    }
}
