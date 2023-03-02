using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITISchoolConsoleApp
{
    public  class SchoolContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ITISchoolDB;Integrated Security=true;Encrypt=false");


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Person>()
            //    .HasDiscriminator(P => P.IsEmployee)
            //    .HasValue<Teacher>(true)
            //    .HasValue<Student>(false);

            ///Default Discriminator
            //modelBuilder.Entity<Person>().
            //    Property("Discriminator")
            //    .HasMaxLength(40);

            //modelBuilder.Entity<Person>().UseTphMappingStrategy(); ///Default


            ///TPH default

            modelBuilder.Entity<Person>().UseTpcMappingStrategy(); ///Table per Concerete Class


            base.OnModelCreating(modelBuilder);
        }

        //public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Student> Students { get; set; }



    }



}
