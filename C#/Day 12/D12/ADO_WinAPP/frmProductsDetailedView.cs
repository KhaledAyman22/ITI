using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_WinAPP
{
    public partial class frmProductsDetailedView : Form
    {
        public frmProductsDetailedView()
        {
            InitializeComponent();
        }

        SqlConnection SqlCn;
        SqlCommand sqlCmd;
        SqlDataAdapter sqlDA;
        DataTable DtPrds;

        SqlCommand sqlCmdUpdatePrice;
        private void frmProductsDetailedView_Load(object sender, EventArgs e)
        {
            SqlCn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthWindCN"].ConnectionString);
            sqlCmd = new SqlCommand("SelectAllProducts", SqlCn);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlDA = new SqlDataAdapter(sqlCmd);
            DtPrds = new DataTable();

            sqlDA.Fill(DtPrds);

            /////Complex Data Binding
            //lstPrds.DataSource = DtPrds;
            //lstPrds.DisplayMember = "ProductName";
            //lstPrds.ValueMember = "ProductID";

            //sqlCmdUpdatePrice = new();
            //sqlCmdUpdatePrice.CommandText = "UPDATE Products SET UnitPrice = @UnitPrice WHERE  (ProductID = @ProductID)";
            //sqlCmdUpdatePrice.Connection = SqlCn;

            //sqlCmdUpdatePrice.Parameters.Add("@UnitPrice", SqlDbType.Money);
            //sqlCmdUpdatePrice.Parameters.Add("@ProductID", SqlDbType.Int);

            BindingSource PrdBindingSource = new BindingSource(DtPrds, "");

            ///Simple Data Binding
            lblPrdID.DataBindings.Add("Text", PrdBindingSource, "ProductID");
            txtPrdName.DataBindings.Add("Text", PrdBindingSource, "ProductName");
            numUnitsInStock.DataBindings.Add("Value", PrdBindingSource, "UnitsInStock");


            btnMoveNext.Click += (sender, e) => PrdBindingSource.MoveNext();
            btnMovePrev.Click += (sender, e) => PrdBindingSource.MovePrevious();

            BindingNavigator bindingNavigator = new BindingNavigator(PrdBindingSource);
            this.Controls.Add(bindingNavigator);


        }

        private void lstPrds_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = lstPrds.SelectedValue.ToString();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            if (( decimal.TryParse(txtNewPrice.Text , out decimal PrdPrice)) && (lstPrds.SelectedItems.Count > 0))
            {
                sqlCmdUpdatePrice.Parameters["@UnitPrice"].Value = PrdPrice;
                sqlCmdUpdatePrice.Parameters["@ProductID"].Value = lstPrds.SelectedValue;

                SqlCn.Open();

                if (sqlCmdUpdatePrice.ExecuteNonQuery() > 0)
                    this.Text = "Done";
                else
                    this.Text = "Error";

                SqlCn.Close();
            }
        }
    }
}
