using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindConsoleApp.Entities
{
    [Keyless]
    public class TenMostExpensiveProductsResult
    {
        public string TenMostExpensiveProducts { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
