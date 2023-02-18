global using Microsoft.Data.SqlClient;
global using System.Configuration;
global using System.Data;

namespace ADO_WinAPP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection SqlCn;
        SqlCommand sqlCmd;
        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCn = new SqlConnection();
            SqlCn.ConnectionString = ConfigurationManager.ConnectionStrings["NorthWindCN"].ConnectionString;
            //@"Data Source=.\MSSQL2019;initial Catalog=Northwind;" +
            //"Integrated Security=true;TrustServerCertificate=true";//Encrypt=false";

            //SqlCn.StateChange += (sender, e) => this.Text = $"State was {e.OriginalState} , Current State {e.CurrentState}";

            this.Text = $"BranchID : {ConfigurationManager.AppSettings["BranchID"]}";

            sqlCmd = new SqlCommand();
            sqlCmd.Connection = SqlCn;
            //sqlCmd.CommandType = CommandType.Text; ///Default
            //sqlCmd.CommandText = "select count(*) from Products";
            sqlCmd.CommandText = "Select * from Products";

        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (SqlCn.State == ConnectionState.Closed)
                SqlCn.Open();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (SqlCn.State == ConnectionState.Open)
                SqlCn.Close();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (SqlCn.State == ConnectionState.Closed)
                SqlCn.Open();

            //this.Text = sqlCmd.ExecuteScalar()?.ToString() ?? "-1";

            SqlDataReader Dr = sqlCmd.ExecuteReader();

            while(Dr.Read())
            {
                this.lstProductsName.Items.Add(Dr.GetString("ProductName"));

                ///Read Only
                //Dr["ProductName"] = "New Prd Name";
            }

            ///Can't Bind Directly to DataReader
            //lstProductsName.DataSource = Dr;

            SqlCn.Close();
        }
    }
}