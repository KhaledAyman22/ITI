using BLL.EntityManager;
using DAL.Models;
using System;
using System.ComponentModel;

namespace Task_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TitleManager.Save();
        }

        private void LoadData()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.DataSource = TitleManager.SelectAllTitlesWithBinding();
            
            dataGridView1.Columns["Pub"].Visible = false;

            DataGridViewComboBoxColumn col = new();
            col.Name = "Pub";
            col.DataSource = PublisherManager.GetPublisherNamesWithIDs();
            col.DisplayMember = "PubName";
            col.ValueMember = "PubId";
            col.DataPropertyName = "PubId";

            dataGridView1.Columns.Add(col);
        }

    }
}