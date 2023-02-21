using BLL.Entity;
using BLL.EntityList;
using BLL.EntityManager;
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

namespace NorthWind_WinApp
{
    public partial class frmDetailedViewPrds : Form
    {
        public frmDetailedViewPrds()
        {
            InitializeComponent();
        }

        ProductList PrdLst;
        BindingNavigator bindingNavigator;
        private void frmDetailedViewPrds_Load(object sender, EventArgs e)
        {
            PrdLst = ProductManager.SelectAllProducts();

            prdBindingSource.DataSource = PrdLst;

            lblProductID.DataBindings.Add("Text", prdBindingSource, "ProductID");
            txtProductName.DataBindings.Add("Text", prdBindingSource, "ProductName");
            numUnitsinStock.DataBindings.Add("value", prdBindingSource, "UnitsInStock");
            
            bindingNavigator = new BindingNavigator(prdBindingSource);
            this.Controls.Add(bindingNavigator);

            prdBindingSource.AddingNew += (sender, e) =>
            e.NewObject = new Product() { State = EntityState.Added, UnitsInStock = 1 };

        }

        private void button1_Click(object sender, EventArgs e)
        {
            prdBindingSource.EndEdit();
            foreach (var item in PrdLst)
                Trace.WriteLine(item.State);
        }
    }
}
