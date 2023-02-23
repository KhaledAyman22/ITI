using D14_EF01.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D14_EF01.Context
{
    public class LibraryContext :DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(@"Data Source=.\MSSQL2019;Initial Catalog=LibraryDB;Integrated Security=true;Encrypt=false");
       


        public virtual DbSet<Title> Titles { get; set; }

        ///Newer Style
        public DbSet<Branch>  Branches => Set<Branch>();
    }
}
