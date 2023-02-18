using Microsoft.Data.SqlClient;
using SQLHelper;
using System.Configuration;
using System.Data;
using System.Security.Policy;

namespace Task_1
{
    public partial class Form1 : Form
    {
        SqlCommand? com = null;
        SqlDataAdapter? adapter = null;
        DataTable? dt = null;

        public Form1()
        {
            InitializeComponent();
            dt = new();
            
            com = new("select p.*, c.CategoryName from products p join Categories c on p.CategoryID = c.CategoryID", Helper.Connection);
            adapter = new(com);
        }

        private void Load_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            Helper.OpenConnection();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Helper.CloseConnection();
            dt?.Clear();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (adapter != null)
            {
                dataGridView1.EndEdit();

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
        
        private void LoadData()
        {
            if (Helper.Connection.State == ConnectionState.Open)
            {
                dt?.Clear();
                dataGridView1.Columns.Clear();
                adapter?.Fill(dt);

                DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();

                comboBoxColumn.Items.AddRange(Helper.Categories.Keys.ToArray());
                comboBoxColumn.DataPropertyName = "CategoryName";
                comboBoxColumn.HeaderText = "Category";
                comboBoxColumn.DisplayMember = "CategoryName";
                comboBoxColumn.ValueMember = "CategoryID";


                dataGridView1.DataSource = dt;
                dataGridView1.Columns.Add(comboBoxColumn);

                dataGridView1.Columns.RemoveAt(10);
                dataGridView1.Columns.RemoveAt(3);

                dataGridView1.Columns[^1].DisplayIndex = 3;
            }
            else
            {
                MessageBox.Show("Open a connection first!");
            }
        }
    }
}