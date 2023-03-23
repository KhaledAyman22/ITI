// See https://aka.ms/new-console-template for more information
using Dapper;
using Microsoft.EntityFrameworkCore;
using NorthWindConsoleEF.Context;
using NorthWindConsoleEF.Models;
using System.Data;

NorthwindContext Context = new NorthwindContext();

IDbConnection dbConnection =  Context.Database.GetDbConnection();
///Select using Dapper
var Prd = dbConnection.QueryFirstOrDefault<Product>("Select * from Products where ProductID = @ProductID",
     new { ProductID = 5 });
Context.Products.Attach(Prd);

Prd.UnitsInStock = 0;
Prd.ProductName += "Updated By EF";



///Update using EF
Console.WriteLine(Context.SaveChanges());

