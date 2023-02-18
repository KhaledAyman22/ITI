using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.Data;

namespace SQLHelper
{
    public static class Helper
    {
        //static public void SetBuilder(SqlDataAdapter adapter, SqlCommand InsertCmd, SqlCommand UpdateCmd, SqlCommand DeleteCmd)
        //{
        //    adapter.InsertCommand = InsertCmd;
        //    adapter.UpdateCommand = UpdateCmd;
        //    adapter.DeleteCommand = DeleteCmd;
        //}

        private static SqlCommand InsertCmd, UpdateCmd, DeleteCmd;
        
        public static SqlConnection Connection { get; }
        
        public static Dictionary<string, int> Categories { get; }


        static Helper()
        {
            Categories = new();
            Connection = new("Data Source=KHALED;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            {
                SqlCommand com = new("select distinct CategoryID, CategoryName from Categories", Connection);
                SqlDataAdapter adapter = new(com);
                DataTable t = new();
                adapter.Fill(t);

                foreach (DataRow row in t.Rows)
                {
                    Categories.Add((string)row[1], (int)row[0]);
                }
            }

            InsertCmd = new("insert into Products values(" +
                "@ProductName," +
                "@SupplierID," +
                "@CategoryID," +
                "@QuantityPerUnit," +
                "@UnitPrice," +
                "@UnitsInStock," +
                "@UnitsOnOrder," +
                "@ReorderLevel," +
                "@Discontinued" +
                ")", Connection);


            UpdateCmd = new("update products set " +
                "ProductName = @ProductName," +
                "SupplierID = @SupplierID," +
                "CategoryID = @CategoryID," +
                "QuantityPerUnit = @QuantityPerUnit," +
                "UnitPrice = @UnitPrice," +
                "UnitsInStock = @UnitsInStock," +
                "UnitsOnOrder = @UnitsOnOrder," +
                "ReorderLevel = @ReorderLevel," +
                "Discontinued = @Discontinued" +
                " where ProductID = @ProductID", Connection);

            DeleteCmd = new("delete from products where ProductID = @ProductID", Connection);

            InsertCmd.Parameters.Add("@ProductName", SqlDbType.NVarChar);
            InsertCmd.Parameters.Add("@SupplierID", SqlDbType.Int);
            InsertCmd.Parameters.Add("@CategoryID", SqlDbType.Int);
            InsertCmd.Parameters.Add("@QuantityPerUnit", SqlDbType.NVarChar);
            InsertCmd.Parameters.Add("@UnitPrice", SqlDbType.Money);
            InsertCmd.Parameters.Add("@UnitsInStock", SqlDbType.SmallInt);
            InsertCmd.Parameters.Add("@UnitsOnOrder", SqlDbType.SmallInt);
            InsertCmd.Parameters.Add("@ReorderLevel", SqlDbType.SmallInt);
            InsertCmd.Parameters.Add("@Discontinued", SqlDbType.Bit);

            UpdateCmd.Parameters.Add("@ProductName", SqlDbType.NVarChar);
            UpdateCmd.Parameters.Add("@SupplierID", SqlDbType.Int);
            UpdateCmd.Parameters.Add("@CategoryID", SqlDbType.Int);
            UpdateCmd.Parameters.Add("@QuantityPerUnit", SqlDbType.NVarChar);
            UpdateCmd.Parameters.Add("@UnitPrice", SqlDbType.Money);
            UpdateCmd.Parameters.Add("@UnitsInStock", SqlDbType.SmallInt);
            UpdateCmd.Parameters.Add("@UnitsOnOrder", SqlDbType.SmallInt);
            UpdateCmd.Parameters.Add("@ReorderLevel", SqlDbType.SmallInt);
            UpdateCmd.Parameters.Add("@Discontinued", SqlDbType.Bit);
            UpdateCmd.Parameters.Add("@ProductID", SqlDbType.Int);

            DeleteCmd.Parameters.Add("@ProductID", SqlDbType.Int);
        }

        static public void Insert(DataRow row)
        {
            InsertCmd.Parameters["@ProductName"].Value = row["ProductName"];
            InsertCmd.Parameters["@SupplierID"].Value = row["SupplierID"];
            InsertCmd.Parameters["@CategoryID"].Value = Categories[(string)row["CategoryName"]];
            InsertCmd.Parameters["@QuantityPerUnit"].Value = row["QuantityPerUnit"];
            InsertCmd.Parameters["@UnitPrice"].Value = row["UnitPrice"];
            InsertCmd.Parameters["@UnitsInStock"].Value = row["UnitsInStock"];
            InsertCmd.Parameters["@UnitsOnOrder"].Value = row["UnitsOnOrder"];
            InsertCmd.Parameters["@ReorderLevel"].Value = row["ReorderLevel"];
            InsertCmd.Parameters["@Discontinued"].Value = row["Discontinued"];

            InsertCmd.ExecuteNonQuery();
        }

        static public void Update(DataRow row)
        {
            UpdateCmd.Parameters["@ProductName"].Value = row["ProductName"];
            UpdateCmd.Parameters["@SupplierID"].Value = row["SupplierID"];
            UpdateCmd.Parameters["@CategoryID"].Value = Categories[(string)row["CategoryName"]];
            UpdateCmd.Parameters["@QuantityPerUnit"].Value = row["QuantityPerUnit"];
            UpdateCmd.Parameters["@UnitPrice"].Value = row["UnitPrice"];
            UpdateCmd.Parameters["@UnitsInStock"].Value = row["UnitsInStock"];
            UpdateCmd.Parameters["@UnitsOnOrder"].Value = row["UnitsOnOrder"];
            UpdateCmd.Parameters["@ReorderLevel"].Value = row["ReorderLevel"];
            UpdateCmd.Parameters["@Discontinued"].Value = row["Discontinued"];
            UpdateCmd.Parameters["@ProductID"].Value = row["ProductID"];

            UpdateCmd.ExecuteNonQuery();
        }

        static public void Delete(DataRow row)
        {
            DeleteCmd.Parameters["@ProductID"].Value = row[0, DataRowVersion.Original];

            DeleteCmd.ExecuteNonQuery();
        }

        static public void OpenConnection()
        {
            if(Connection.State!=ConnectionState.Open) Connection.Open();
        }

        static public void CloseConnection()
        {
            if (Connection.State != ConnectionState.Closed) Connection.Close();
        }
    }
}