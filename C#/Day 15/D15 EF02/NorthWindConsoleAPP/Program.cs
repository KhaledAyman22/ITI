using Microsoft.EntityFrameworkCore;
using NorthWindConsoleAPP.Context;

namespace NorthWindConsoleAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using NorthwindContext Context = new();

            var Result = (from P in Context.Products
                          //.Include(P=>P.Category).Include(P=> P.Supplier)
                          where P.UnitsInStock == 0
                          select P
                          //select P.ProductName
                          //select new {P.ProductName , P.Category.CategoryName}
                          //select new { P.ProductName, P.Category.CategoryName, P.Supplier.CompanyName }
                          ).ToList();


            foreach (var item in Result)
            {
                //if (item.Category == null)
                //    ///Explicit Loading
                //    Context.Entry(item).Reference(P => P.Category).Load();

                ///To get the same result as Explicit Loading Automatically without any extra code
                ///Install-Package Microsoft.EntityFrameworkcore.Proxy
                ///OptionBuilder.UseLazyLoadingProxies();


                Console.WriteLine($"Product {item.ProductName} , Category {item.Category?.CategoryName ?? "NA"}");
                //Console.WriteLine($"Product {item.ProductName} , Category {item.Category?.CategoryName ?? "NA"} " +
                //    $", Supplier Company {item.Supplier.CompanyName}");

            }



;
        }
    }
}