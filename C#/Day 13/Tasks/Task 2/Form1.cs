using BLL.Entity;
using BLL.EntityList;
using BLL.EntityManager;

namespace Task_2
{
    public partial class Form1 : Form
    {
        TitleList titles;
        BindingNavigator bNav;

        public Form1()
        {
            InitializeComponent();
            
            titles = TitleManager.SelectAllTitles();

            bSrc.DataSource = titles;

            bNav = new(bSrc);
            Controls.Add(bNav);

            bSrc.AddingNew += (sender, e) =>
            {
                titles.Add(new Title()
                {
                    TitleID = "",
                    TitleName = "",
                    Type = "",
                    PublisherID = "",
                    Price = 0M,
                    Advance = 0M,
                    Royalty = 0,
                    YTDSales = 0,
                    Notes = "",
                    PublishDate = new(1999, 1, 1),
                    State = EntityState.Added
                });

                bSrc.MoveLast();
            };

            bSrc.CurrentItemChanged += (sender, e) =>
            {
                ((Title)bSrc.Current).State = ((Title)bSrc.Current).State == EntityState.Added ? EntityState.Added : EntityState.Changed;
            };

            bNav.DeleteItem.MouseDown += (sender, e) =>
            {
                if (TitleManager.DeleteTitle((Title)bSrc.Current))
                    bSrc.RemoveCurrent();
                else
                {
                    MessageBox.Show("Couldn't delete due to refrence dependency");
                    bSrc.CancelEdit();
                }
            };

            price.ValueChanged += (sender, e) =>
            {
                ((Title)bSrc.Current).Price = price.Value;
                ((Title)bSrc.Current).State = ((Title)bSrc.Current).State == EntityState.Added? EntityState.Added : EntityState.Changed;
            };

            advance.ValueChanged += (sender, e) =>
            {
                ((Title)bSrc.Current).Advance = advance.Value;
                ((Title)bSrc.Current).State = ((Title)bSrc.Current).State == EntityState.Added ? EntityState.Added : EntityState.Changed;
            };

            royalty.ValueChanged += (sender, e) =>
            {
                ((Title)bSrc.Current).Royalty = (int)royalty.Value;
                ((Title)bSrc.Current).State = ((Title)bSrc.Current).State == EntityState.Added ? EntityState.Added : EntityState.Changed;
            };

            ytd.ValueChanged += (sender, e) =>
            {
                ((Title)bSrc.Current).YTDSales = (int)ytd.Value;
                ((Title)bSrc.Current).State = ((Title)bSrc.Current).State == EntityState.Added ? EntityState.Added : EntityState.Changed;
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            publisherCombo.DataSource = PublisherManager.GetPublisherNamesWithIDs();
            publisherCombo.DisplayMember = "Pub_Name";
            publisherCombo.ValueMember = "Pub_ID";


            titleId.DataBindings.Add("Text", bSrc, "TitleID");
            title.DataBindings.Add("Text", bSrc, "TitleName");
            type.DataBindings.Add("Text", bSrc, "Type");
            publisherCombo.DataBindings.Add("SelectedValue", bSrc, "PublisherID");
            price.DataBindings.Add("Value", bSrc, "Price");
            advance.DataBindings.Add("Value", bSrc, "Advance");
            royalty.DataBindings.Add("Value", bSrc, "Royalty");
            ytd.DataBindings.Add("Value", bSrc, "YTDSales");
            notes.DataBindings.Add("Text", bSrc, "Notes");
            publishDate.DataBindings.Add("Value", bSrc, "PublishDate");

            

        }

        private void save_Click(object sender, EventArgs e)
        {
            bSrc.EndEdit();
            TitleManager.Save(titles);
            titles = TitleManager.SelectAllTitles();
        }
    }
}