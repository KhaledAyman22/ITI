using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace DAL
{
    public class DBManager
    {

        SqlConnection sqlCN;
        SqlCommand sqlCmd;
        SqlDataAdapter sqlDA;
        DataTable Dt;

        public DBManager()
        {
            try
            {
                sqlCN = new(ConfigurationManager.ConnectionStrings["PubsCN"].ConnectionString);
                sqlCmd = new()
                {
                    CommandType = CommandType.StoredProcedure,
                    Connection = sqlCN
                };
                sqlDA = new(sqlCmd);
                Dt = new();
            }
            catch
            {
                //Logg Exception
            }
        }

        public int ExecuteNonQuery(string SPName)
        {
            try
            {
                sqlCmd.Parameters.Clear();

                sqlCmd.CommandText = SPName;

                if (sqlCN.State == ConnectionState.Closed)
                    sqlCN.Open();

                return sqlCmd.ExecuteNonQuery();

            }
            catch
            {
                return -1;
            }
            finally
            {
                sqlCN.Close();
            }
        }

        public int ExecuteNonQuery(string SPName, Dictionary<string, object> ParmLst)
        {
            try
            {
                sqlCmd.Parameters.Clear();

                foreach (var item in ParmLst)
                    sqlCmd.Parameters.Add(new SqlParameter(item.Key, item.Value));

                sqlCmd.CommandText = SPName;

                if (sqlCN.State == ConnectionState.Closed)
                    sqlCN.Open();

                return sqlCmd.ExecuteNonQuery();

            }
            catch
            {
                return -1;
            }
            finally
            {
                sqlCN.Close();
            }
        }

        public object ExecuteScalar(string SPName)
        {
            try
            {
                sqlCmd.Parameters.Clear();

                sqlCmd.CommandText = SPName;

                if (sqlCN.State == ConnectionState.Closed)
                    sqlCN.Open();

                return sqlCmd.ExecuteScalar();

            }
            catch
            {
                return new();
            }
            finally
            {
                sqlCN.Close();
            }
        }

        public object ExecuteScalar(string SPName, Dictionary<string, object> ParmLst)
        {
            throw new NotImplementedException();
        }
        
        public DataTable ExecuteDataTable(string SPName)
        {
            try
            {
                Dt.Clear();
                sqlCmd.Parameters.Clear();

                sqlCmd.CommandText = SPName;

                sqlDA.Fill(Dt);

                return Dt;
            }
            catch
            {
                return new();
            }
        }

        public DataTable ExecuteDataTable(string SPName, Dictionary<string, object> ParmLst)
        {
            try
            {
                Dt.Clear();
                sqlCmd.Parameters.Clear();

                foreach (var item in ParmLst)
                    sqlCmd.Parameters.Add(new SqlParameter(item.Key, item.Value));

                sqlCmd.CommandText = SPName;

                sqlDA.Fill(Dt);

                return Dt;
            }
            catch
            {
                return new();
            }
        }

    }
}