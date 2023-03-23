using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UI
{
    public class DapperConnection
    {
        public static IDbConnection Connection { get; }
        
        static DapperConnection()
        {
            Connection = new SqlConnection("Data Source=KHALED;Initial Catalog=HotelManagmentSystem;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            Connection.Open();
        }
    }
}
