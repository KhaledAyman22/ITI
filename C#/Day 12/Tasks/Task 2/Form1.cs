using Microsoft.Data.SqlClient;
using SQLHelper;
using System.Data;


namespace Task_2
{
    public partial class Form1 : Form
    {
        SqlCommand? com = null;
        SqlDataAdapter? adapter = null;
        DataTable dt = new();

        BindingSource bSrc = new();
        BindingNavigator bNav;

        public Form1()
        {
            InitializeComponent();

            dt = new();
            
            com = new("select p.*, c.CategoryName from products p join Categories c on p.CategoryID = c.CategoryID", Helper.Connection);
            adapter = new(com);

            cat.Items.AddRange(Helper.Categories.Keys.ToArray());

            bNav = new(bSrc);
            Controls.Add(bNav);

            btnMoveNext.Click += (sender, e) => bSrc.MoveNext();
            btnMovePrev.Click += (sender, e) => bSrc.MovePrevious();
            cat.SelectedIndexChanged += (sender, e) => {
                if (sender is ComboBox c)
                {
                    if (Helper.Categories.TryGetValue(c?.SelectedItem?.ToString() ?? "", out int i))
                        ((DataRowView)bNav.BindingSource.Current)["CategoryID"] = i;
                }
            };
        }

        private void BtnExecute_Click(object sender, EventArgs e)
        {
            if (adapter != null)
            {
                bSrc.EndEdit();

                try
                {
                    Helper.OpenConnection();

                    foreach (DataRow row in dt.Rows)
                    {
                        int state = row.RowState switch
                        {
                            DataRowState.Deleted => 1,
                            DataRowState.Modified => 2,
                            DataRowState.Added => 3,
                            _ => 0
                        };

                        if (state != 0)
                        {
                            switch (state)
                            {
                                case 1: Helper.Delete(row); break;
                                case 2: Helper.Update(row); break;
                                case 3: Helper.Insert(row); break;
                            };
                        }
                    }

                    MessageBox.Show("Updated Successfully");
                }
                catch (Exception)
                {
                    MessageBox.Show("Couldn't update due to existing refrences");
                    LoadData();
                }
                finally
                {
                    Helper.CloseConnection();
                }
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            LoadData();

            bSrc.DataSource = dt;
            id_val.DataBindings.Add("Text", bSrc, "ProductID");
            txtPrdName.DataBindings.Add("Text", bSrc, "ProductName");
            numUnitsInStock.DataBindings.Add("Value", bSrc, "UnitsInStock");
            price.DataBindings.Add("Value", bSrc, "UnitPrice");
            cat.DataBindings.Add("SelectedItem", bSrc, "CategoryName");
        }

        private void LoadData()
        {
            Helper.OpenConnection();
            dt.Clear();
            adapter = new(com);
            adapter.Fill(dt);
            Helper.CloseConnection();
        }
    }
}