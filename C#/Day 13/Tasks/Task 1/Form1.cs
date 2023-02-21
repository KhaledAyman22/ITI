using BLL.Entity;
using BLL.EntityList;
using BLL.EntityManager;
using System;
using System.ComponentModel;

namespace Task_1
{
    public partial class Form1 : Form
    {
        TBindingList bindingList;
        TitleList titles;
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TitleManager.Save(bindingList.ToList());
            LoadData();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            titles = TitleManager.SelectAllTitles();
            bindingList = new(titles);
            dataGridView1.DataSource = bindingList;

            DataGridViewComboBoxColumn col = new();
            col.Name = "Publisher";
            col.DataSource = PublisherManager.GetPublisherNamesWithIDs();
            col.DisplayMember = "Pub_Name";
            col.ValueMember = "Pub_ID";
            col.DataPropertyName = "PublisherID";

            dataGridView1.Columns.Add(col);
        }

    }
}