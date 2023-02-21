using BLL.EntityManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthWind_WinApp
{
    public partial class frmManageProducts : Form
    {
        public frmManageProducts()
        {
            InitializeComponent();
        }

        private void frmManageProducts_Load(object sender, EventArgs e)
        {
            this.lblProductID.Text = "1";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((int.TryParse(lblProductID.Text, out int PID)) && (txtProductName.Text?.Length > 0))
            {
                var Status = ProductManager.UpdateProductNameByProductID(PID, txtProductName.Text);

                this.Text = $"{Status}";
            }
        }
    }
}
