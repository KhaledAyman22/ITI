using Microsoft.EntityFrameworkCore;
using MVVMDay23.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDay23.DataAccess
{
    public class SchoolDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"data source=DESKTOP-3UB21BV\SQLEXPRESS01;initial catalog=SchoolDataBase;integrated security=true;trustservercertificate=true;");
           
        }
    }
}
