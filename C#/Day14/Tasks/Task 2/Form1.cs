using BLL.EntityManager;
using DAL.Models;
using System.Diagnostics;
using System.Security.Policy;
using System.Windows.Forms;
using static Azure.Core.HttpHeader;

namespace Task_2
{
    public partial class Form1 : Form
    {
        BindingNavigator bNav;

        public Form1()
        {
            InitializeComponent();
            
            bSrc.DataSource = TitleManager.SelectAllTitlesWithBinding();

            bNav = new(bSrc);
            Controls.Add(bNav);

            price.ValueChanged += (sender, e) =>
            {
                ((Title)bSrc.Current).Price = price.Value;
            };

            advance.ValueChanged += (sender, e) =>
            {
                ((Title)bSrc.Current).Advance = advance.Value;
            };

            royalty.ValueChanged += (sender, e) =>
            {
                ((Title)bSrc.Current).Royalty = (int)royalty.Value;
            };

            ytd.ValueChanged += (sender, e) =>
            {
                ((Title)bSrc.Current).YtdSales = (int)ytd.Value;
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            publisherCombo.DataSource = PublisherManager.GetPublisherNamesWithIDs();
            publisherCombo.DisplayMember = "PubName";
            publisherCombo.ValueMember = "PubId";


            titleId.DataBindings.Add("Text", bSrc, "TitleId");
            title.DataBindings.Add("Text", bSrc, "Title1");
            type.DataBindings.Add("Text", bSrc, "Type");
            publisherCombo.DataBindings.Add("SelectedValue", bSrc, "PubId");
            price.DataBindings.Add("Value", bSrc, "Price");
            advance.DataBindings.Add("Value", bSrc, "Advance");
            royalty.DataBindings.Add("Value", bSrc, "Royalty");
            ytd.DataBindings.Add("Value", bSrc, "YtdSales");
            notes.DataBindings.Add("Text", bSrc, "Notes");
            publishDate.DataBindings.Add("Value", bSrc, "Pubdate");
        }

        private void save_Click(object sender, EventArgs e)
        {
            bSrc.EndEdit();
            if (!TitleManager.Save())
            {
                bSrc.DataSource = TitleManager.SelectAllTitlesWithBinding();
                bNav.BindingSource = bSrc;
                MessageBox.Show("Couldn't delete due to refrence conflict");
            }

        }
    }
}