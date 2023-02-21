using Microsoft.EntityFrameworkCore;
using NorthWindApp.Context;

namespace NorthWindApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.FormClosed += (sender, e) => Context?.Dispose();
        }

        NorthwindContext Context = new();

        private void Form1_Load(object sender, EventArgs e)
        {
            //var Prds = (from P in Context.Products
            //           where P.UnitsInStock == 0
            //           select P).ToList();

            //this.dataGridView1.DataSource = Prds;

            Context.Products.Load();

            this.dataGridView1.DataSource =
                Context.Products.Local.ToBindingList();

        }
    }
}