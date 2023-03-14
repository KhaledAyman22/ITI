using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace IdentityWebApp_43.Models
{
    public class MainDbContext:DbContext
    {
        public MainDbContext():base("myConn")
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}