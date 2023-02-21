using BLL.EntityList;
using BLL.EntityManager;
using System.Diagnostics;

namespace NorthWind_WinApp
{
    public partial class frmPrdsGridView : Form
    {
        public frmPrdsGridView()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        ProductList PrdLst;

        private void Form1_Load(object sender, EventArgs e)
        {
            PrdLst = ProductManager.SelectAllProducts();
            grdViewPrds.DataSource = PrdLst;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var item in PrdLst)
            {
                Trace.WriteLine(item.State);
            }
        }
    }
}