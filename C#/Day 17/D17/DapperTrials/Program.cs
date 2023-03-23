using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using DapperTrials;

#region Dapper EX01

//IDbConnection dbConnection = new SqlConnection("Data Source=.;Initial Catalog=Northwind;" +
//    "Integrated Security=true;Encrypt=false");

//var R = dbConnection.ExecuteScalar("Select Count(*) from Products");
//Console.WriteLine(R);


//var Prds = dbConnection.Query<Product>("Select * From Products where UnitsInStock=0");

//var Prds = dbConnection.Query<Product>("Select * From Products where UnitsInStock=@Units",
//new { Units =0});
//var Prds = dbConnection.Query<Product>("SelectAllProducts" , commandType: CommandType.StoredProcedure)
//            ///L2Object not L2EF , Take will execute in memory , against local Seq not Remote Seq
//            .Take(5);


//foreach (var item in Prds)
//{
//    Console.WriteLine( item.ProductName );
//} 
#endregion

var PrdManager = new ProductManager();

var Prd = PrdManager.GetByID(5);

Prd.UnitsInStock = 20;

PrdManager.Update(Prd);