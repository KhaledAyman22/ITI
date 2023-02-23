using CompanyConsoleAPP.Configurations;
using CompanyConsoleAPP.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyConsoleAPP.Context
{
    /// <summary>
    /// 4 ways for Mapping
    /// 1. EF Convensions
    /// 2. Data Annotations
    /// 3. Fluent API
    /// 4. Configuration Class 
    /// refactoring Fluent API into Seprate class per entity 
    /// </summary>


    public class CompanyContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(@"Data Source=.\MSSQL2019;Initial Catalog=Company2023DB;Integrated Security=true;Encrypt=false");


        ///3. Fluent API 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Original Style for Fluent API

            //modelBuilder.Entity<Client>()
            //    .Ignore( C => C.TimeStamp)
            //    .HasKey(C => C.CID);

            //modelBuilder.Entity<Client>().Property(C => C.FName)
            //    .HasMaxLength(50);

            //modelBuilder.Entity<Client>().Property(C => C.LName)
            //    .HasMaxLength(50);

            //modelBuilder.Entity<Client>().Property(C => C.MName)
            //    .HasMaxLength(2)
            //    .IsFixedLength()
            //    .IsRequired(false);

            //modelBuilder.Entity<Client>().Property(C => C.Deposit)
            //    .HasColumnType("money")
            //    .HasColumnName("OrderDeposite");

            #endregion

            #region  New Style for Fluent API

            //modelBuilder.Entity<Client>(EntityBuilder =>
            //{
            //    EntityBuilder.Ignore(C => C.TimeStamp)
            //       .HasKey(C => C.CID);

            //    EntityBuilder.Property(C => C.FName)
            //        .HasMaxLength(50);

            //    EntityBuilder.Property(C => C.LName)
            //        .HasMaxLength(50);

            //    EntityBuilder.Property(C => C.MName)
            //        .HasMaxLength(2)
            //        .IsFixedLength()
            //        .IsRequired(false);

            //    EntityBuilder.Property(C => C.Deposit)
            //        .HasColumnType("money")
            //        .HasColumnName("OrderDeposite");
            //});


            //modelBuilder.Entity<Branch>(EntityBuilder => {
            //    EntityBuilder.Property(B => B.Name).HasMaxLength(20);
            //    EntityBuilder.Property(B => B.City).HasMaxLength(10).IsUnicode();
            //});
            #endregion


            modelBuilder.Entity<EmployeeClient>()
                .HasKey(EC => new { EC.ClientCID, EC.EmployeeEID });

            ///4. Configuration Class
            modelBuilder.ApplyConfiguration(new ClientEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BranchConfigration());


            base.OnModelCreating(modelBuilder);
        }


        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Branch>  Branches { get; set; }


    }
}
