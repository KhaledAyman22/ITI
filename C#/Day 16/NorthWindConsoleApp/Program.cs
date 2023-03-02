// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using NorthWindConsoleApp.Context;
using NorthWindConsoleApp.Entities;

using NorthwindContext Context = new();

#region Find , Local
//var Results = Context.Products.Take(3).ToList();

//Console.WriteLine(Context.Products.Count());
/////DB

//Console.WriteLine(Context.Products.Local.Count());
/////No DB Trip , from Local

////if (Context.Products.Any(p=> p.UnitsInStock==0))
////    Console.WriteLine("Out of Stock Products");


////if (Context.Products.Local.Any(p => p.UnitsInStock == 0))
////    Console.WriteLine("Out of Stock Products");
////else if (Context.Products.Any(p => p.UnitsInStock == 0))
////    Console.WriteLine("Out of Stock Products");
////else
////    Console.WriteLine("All Products in Stock");


//var Prd = Context.Products.Find(2);

/////if Product.ProductID==2 found in local no Extra Trip to DB

//Prd = Context.Products.Find(15);
/////ProductID=15 not found in Local , Query from DB

//Prd = Context.Products.Find(150);
/////if no Product in DB with ID = 150 , return null , no Exception will be thrown


//Console.WriteLine(  Prd?.ProductName??"NA");

//Console.WriteLine(Context.Products.Local.Count());


//var Result02 = Context.Products.Local.SkipWhile(P => P.UnitPrice > 20).ToList(); 
#endregion

#region ReadOnly , No Tracking

//var Results = Context.Products.Take(10).AsNoTracking().ToList();

//Results[0].ProductName += "+++++";

//Console.WriteLine($"Number of Rows Affected {Context.SaveChanges()}"  );


#endregion

#region Global Query Filter
//var Results = Context.Products.Where(P => P.UnitsInStock == 0).ToList();

//Console.WriteLine(Results.Count);

//var Prd = Context.Products.First(P => P.Category.CategoryId == 2);

//Console.WriteLine(Context.Products.IgnoreQueryFilters().First().ProductName);

#endregion

#region Execute SQL , SPs , EF Core Power Tools
//var Prds = Context.Products.FromSqlRaw("select  *  from Products where UnitsInStock=0 ").ToList();


/////returned Entities still tracked with ChangeTracker
/////
//Prds[0].ProductName += "**";

//var Prd = Context.Products.FromSqlRaw("select  *  from Products where UnitsInStock=0 ")
//                .OrderByDescending(P => P.UnitsInStock)
//                .FirstOrDefault();

///LINQ Query onTop of SqlRaw
///Run in SQL Server not  in Client Memory

//var Prd = Context.Products.FromSqlRaw("Exec SelectAllProducts")
//                .ToList() ///Get ALL Data from DB
//                .OrderByDescending(P => P.UnitsInStock)
//                .FirstOrDefault();


//Prd.ProductName += "**";

//int PrdUnits = 20;
//var Prd = Context.Products.FromSql($"select  Top(1) * from Products where UnitsInStock>{PrdUnits}").FirstOrDefault();
/////Safe Against SQL Injection

//Prd.ProductName += "**";

//Console.WriteLine($"Number of Rows Affected {Context.SaveChanges()}");

//int PrdID = 6;
//string NewName = "Updated On March";

//int R = Context.Database.ExecuteSql($"Exec UpdateProductNameByProductID {PrdID},{NewName}");

//Console.WriteLine(  R);

//int PrdUnits = 0;
//var PrdPrice = Context.Database.SqlQuery<decimal>
//    ($"select  Max(unitPrice) AS Value  from Products where UnitsInStock={PrdUnits} ").First();
/////return Scaler Value

//Console.WriteLine(PrdPrice);

//var Results = Context.Set<TenMostExpensiveProductsResult>().FromSqlRaw("Exec [Ten Most Expensive Products]").ToList();


//foreach (var item in Results)
//    Console.WriteLine($"Product:{item.TenMostExpensiveProducts} , Price : {item.UnitPrice}");

//var SPs = new NorthwindContextProcedures(Context);

//Console.WriteLine(await SPs.UpdateProductNameByProductIDAsync(1, "عرق سوس"));

//var SPResults = await SPs.CustOrderHistAsync("ANATR");

//foreach (var item in SPResults)
//    Console.WriteLine(  item.ProductName);

#endregion