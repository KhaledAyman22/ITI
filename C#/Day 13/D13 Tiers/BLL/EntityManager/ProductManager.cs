using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Entity;
using BLL.EntityList;
using DAL;

namespace BLL.EntityManager
{
    public class ProductManager
    {

        static DBManager manager = new();


        public static bool UpdateProductNameByProductID (int PrdID , string PrdName)
        {
            try
            {

                Dictionary<string, object> ParamDic = new() { ["@ProductID"] = PrdID, ["@ProductName"] = PrdName };

                return
                manager.ExecuteNonQuery("UpdateProductNameByProductID" , ParamDic) > 0;

            }
            catch
            {
                
            }
            return false;
        }

        public static ProductList SelectAllProducts()
        {
            try
            {
                return DataTableToProductList(manager.ExecuteDataTable("SelectAllProducts"));
            }
            catch
            {
                return new ProductList();
            }
        }

        #region Mapping

        internal static ProductList DataTableToProductList (DataTable Dt)
        {
            ProductList PrdLst = new();
            try
            {
                foreach (DataRow row in Dt.Rows)
                    PrdLst.Add(DataRowToProduct(row));
            }
            catch
            {

            }
            return PrdLst;
        }

        internal static Product DataRowToProduct (DataRow Dr)
        {
            Product Prd = new();
            try
            {
                if (int.TryParse(Dr["ProductID"]?.ToString() ?? "-1", out int TempInt))
                    Prd.ProductID = TempInt;

                Prd.ProductName = Dr["ProductName"]?.ToString() ?? "NA";
                
                Prd.QuantityPerUnit = Dr["QuantityPerUnit"]?.ToString() ?? "NA";

                if (int.TryParse(Dr["SupplierID"]?.ToString() ?? "-1", out TempInt))
                    Prd.SupplierID = TempInt;

                if (int.TryParse(Dr["CategoryID"]?.ToString() ?? "-1", out TempInt))
                    Prd.CategoryID = TempInt;

                if (short.TryParse(Dr["ReorderLevel"]?.ToString() ?? "-1", out short TempShort))
                    Prd.ReorderLevel = TempShort;

                if (short.TryParse(Dr["UnitsInStock"]?.ToString() ?? "-1", out  TempShort))
                    Prd.UnitsInStock = TempShort;
                
                if (short.TryParse(Dr["UnitsOnOrder"]?.ToString() ?? "-1", out  TempShort))
                    Prd.UnitsOnOrder = TempShort;

                if (decimal.TryParse(Dr["UnitPrice"]?.ToString() ?? "-1", out decimal TempDecimal))
                    Prd.UnitPrice = TempDecimal;

                if (bool.TryParse(Dr["Discontinued"]?.ToString() ?? "-1", out bool TempBool))
                    Prd.Discontinued = TempBool;

                Prd.State = EntityState.UnChanged;

            }
            catch
            {

            }
            return Prd;
        }

        #endregion

    }
}
