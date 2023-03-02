using Microsoft.EntityFrameworkCore;
using NorthWindConsoleApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindConsoleApp.Context
{
    partial class NorthwindContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TenMostExpensiveProductsResult>().HasNoKey();
        }
    }
}
