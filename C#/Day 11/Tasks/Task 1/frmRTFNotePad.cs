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
        private dlgCust dlgCust = new();
        private OpenFileDialog dlgOpen = new();
        private SaveFileDialog dlgSave = new();
        private FontDialog dlgFont = new();
        private ColorDialog dlgColor = new();

        public frmRTFNotePad()
        {
            InitializeComponent();
        }

        private void FrmRTFNotePad_Load(object sender, EventArgs e)
        {
            MinimumSize = Size;

            btnClose.Click += (sender, e) => Close();
            btnOpen.Click += (sender, e) => OpenClick();
            btnSave.Click += (sender, e) => SaveClick();
            btnFont.Click += (sender, e) => FontClick();
            btnColor.Click += (sender, e) => ColorClick();
            btnCust.Click += (sender, e) => CustClick();
        }

        private void FrmRTFNotePad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (
            MessageBox.Show("Are You Sure You Want to Exit ? (Y|N)",
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
                 == DialogResult.No)
                e.Cancel = true;
        }

        private void OpenClick()
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

        private void SaveClick()
        {
            dlgSave.Filter = "Rich Text Files|*.rtf|Text Files|*.txt";
            dlgSave.InitialDirectory = "D:";

            if (dlgSave.ShowDialog() == DialogResult.OK)
                rtfTxt.SaveFile(dlgSave.FileName , (RichTextBoxStreamType) (dlgSave.FilterIndex - 1));

        }

        private void FontClick()
        {
            if (rtfTxt.SelectedText?.Length > 0)
                dlgFont.Font = rtfTxt.SelectionFont;

            if ( dlgFont.ShowDialog() == DialogResult.OK)
                rtfTxt.SelectionFont = dlgFont.Font;
        }

        private void ColorClick()
        {
            if (rtfTxt.SelectedText?.Length > 0)
                dlgColor.Color = rtfTxt.SelectionColor;

                if (dlgColor.ShowDialog() == DialogResult.OK)
                rtfTxt.SelectionColor = dlgColor.Color;
        }

        private void CustClick()
        {
            dlgCust.UserTxt = "Type Here";
            if (dlgCust.ShowDialog() == DialogResult.OK)
                rtfTxt.AppendText(dlgCust.UserTxt.ToUpper());
        }
    }
}
