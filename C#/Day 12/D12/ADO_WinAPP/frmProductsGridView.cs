using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_WinAPP
{
    public partial class frmProductsGridView : Form
    {
        public frmProductsGridView()
        {
            InitializeComponent();
        }
        SqlConnection SqlCn;
        SqlCommand sqlCmd;
        SqlDataAdapter sqlDA;
        DataTable DtPrds;

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ///Execute Select Command for SqlDA
            sqlDA.Fill(DtPrds);
            ///Open Connection , Execute Command , Fill Data Table , Close Connection

            ///Complex Data Binding
            grdPrds.DataSource = DtPrds;
        }

        private void frmProductsGridView_Load(object sender, EventArgs e)
        {
            SqlCn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthWindCN"].ConnectionString);
            sqlCmd = new SqlCommand("Select * from Products", SqlCn);
            sqlDA = new SqlDataAdapter(sqlCmd);
            DtPrds = new DataTable();

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sqlDA);
            sqlDA.InsertCommand =  commandBuilder.GetInsertCommand();
            sqlDA.UpdateCommand = commandBuilder.GetUpdateCommand();
            sqlDA.DeleteCommand = commandBuilder.GetDeleteCommand();

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (DataRow row in DtPrds.Rows)
            {
                Debug.WriteLine(row.RowState);
            }

            grdPrds.EndEdit();
            sqlDA.Update(DtPrds);
            ///Open DB Connection , Commit Changes to DB (Insert Command , 
            ///Update Command , Delete Command ) , close DB Connection
        }
    }
}
