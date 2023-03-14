using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Task_1.Models
{
    public class IdentityDbContext : DbContext
    {
        public IdentityDbContext():base("IdentityDb")
        {
            
        }

        public DbSet<Client> Clients { get; set; }
    }
}