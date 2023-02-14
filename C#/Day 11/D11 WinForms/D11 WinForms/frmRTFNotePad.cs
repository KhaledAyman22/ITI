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
    public partial class frmRTFNotePad : Form
    {
        public frmRTFNotePad()
        {
            InitializeComponent();
        }

        private void frmRTFNotePad_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;

            btnClose.Click += (sender, e) => this.Close();
        }

        private void frmRTFNotePad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (
            MessageBox.Show("Are You Sure You Want to Exit ? (Y|N)",
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                 == DialogResult.No)
                e.Cancel = true;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dlgOpen.Filter = "Rich Text Files|*.rtf|Text Files|*.txt";

            if (dlgOpen.ShowDialog() == DialogResult.OK)
                switch (dlgOpen.FilterIndex)
                {
                    case 1:
                        rtfTxt.LoadFile(dlgOpen.FileName , RichTextBoxStreamType.RichText);
                        break;
                    case 2:
                        rtfTxt.LoadFile(dlgOpen.FileName, RichTextBoxStreamType.PlainText);
                        break;
                }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dlgSave.Filter = "Rich Text Files|*.rtf|Text Files|*.txt";
            dlgSave.InitialDirectory = "D:";

            if (dlgSave.ShowDialog() == DialogResult.OK)
                rtfTxt.SaveFile(dlgSave.FileName , (RichTextBoxStreamType) (dlgSave.FilterIndex - 1));

        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            if (rtfTxt.SelectedText?.Length > 0)
                dlgFont.Font = rtfTxt.SelectionFont;

            if ( dlgFont.ShowDialog() == DialogResult.OK)
                rtfTxt.SelectionFont = dlgFont.Font;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (rtfTxt.SelectedText?.Length > 0)
                dlgColor.Color = rtfTxt.SelectionColor;

                if (dlgColor.ShowDialog() == DialogResult.OK)
                rtfTxt.SelectionColor = dlgColor.Color;
        }

        dlgCust dlgCust = new();
        private void btnCust_Click(object sender, EventArgs e)
        {
            dlgCust.UserTxt = "Type Here";
            if (dlgCust.ShowDialog() == DialogResult.OK)
                this.rtfTxt.AppendText(dlgCust.UserTxt.ToUpper());
        }
    }
}
