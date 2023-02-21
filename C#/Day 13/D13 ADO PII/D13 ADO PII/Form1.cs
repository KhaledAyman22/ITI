using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace D13_ADO_PII
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection SqlCN;
        SqlCommand sqlCmdSelectAllPrds;
        SqlDataAdapter DAPrds;
        DataTable DTPrds;

        SqlCommand sqlcmdSelectAllCat;
        SqlDataAdapter DACategorie;
        DataTable DTCategories;

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCN = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthWindCN"].ConnectionString);
            sqlCmdSelectAllPrds = new SqlCommand("Select * from Products", SqlCN);
            DAPrds = new SqlDataAdapter(sqlCmdSelectAllPrds);
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(DAPrds);
            DTPrds = new();
            DAPrds.Fill(DTPrds);

            sqlcmdSelectAllCat = new("select CategoryID as CID , CategoryName As CName from Categories", SqlCN);
            DACategorie = new(sqlcmdSelectAllCat);
            DTCategories = new();
            DACategorie.Fill(DTCategories);

            grdViewPrds.DataSource = DTPrds;

            DataGridViewComboBoxColumn col = new();
            col.HeaderText = "Category";
            col.DataSource = DTCategories;
            col.DisplayMember = "CName";
            col.ValueMember = "CID";
            col.DataPropertyName = "CategoryID";
            ///Bind its Value Member with Grid Data Source [ColName]

            grdViewPrds.Columns.Add(col);

            grdViewPrds.Columns[0].ReadOnly = true;
            grdViewPrds.Columns["CategoryID"].Visible = false;


        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grdViewPrds.EndEdit();
            DAPrds.Update(DTPrds);

        }
    }
}