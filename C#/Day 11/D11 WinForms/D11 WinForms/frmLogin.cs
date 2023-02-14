using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D11_WinForms
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            btnClose.Click += (sender, e) => this.Close();
        }

        Form1 FrmHomePage = new();

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if ((txtUserName.Text == "ABC") && (txtPassword.Text == "123"))
            {
                this.Hide();
                FrmHomePage.ShowDialog();
                this.Visible = true;

            }
        }
    }
}
