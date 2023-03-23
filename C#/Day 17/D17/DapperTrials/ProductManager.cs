using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTrials
{
    public class ProductManager : IManager<Product>
    {
        IDbConnection dbConnection = new SqlConnection("Data Source=.;Initial Catalog=Northwind;" +
                "Integrated Security=true;Encrypt=false");
        public bool Add(Product Item)
        {
            try
            {
                return dbConnection.Execute("INSERT INTO Products " +
                    "(ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice, UnitsInStock, UnitsOnOrder, ReorderLevel, Discontinued) " +
                    "VALUES (@ProductName,@SupplierID,@CategoryID,@QuantityPerUnit,@UnitPrice,@UnitsInStock,@UnitsOnOrder,@ReorderLevel,@Discontinued)"
                    ,Item)>0;

            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long ID)
            => dbConnection.Execute("DeleteProductByID", new { @ProductID = ID },
                commandType: CommandType.StoredProcedure ) > 0;

        public List<Product> GetALL() =>
            dbConnection.Query<Product>("Select * from Products")?.ToList() ?? new();

        public Product GetByID(long ID) =>
            dbConnection.QueryFirstOrDefault<Product>("Select * from Products where ProductID = @ProductID",
                new { ProductID = ID });

        public bool Update(Product Item) =>
            dbConnection.Execute("[PrdsUpdate]", Item, commandType: CommandType.StoredProcedure) > 0;
    }
}
