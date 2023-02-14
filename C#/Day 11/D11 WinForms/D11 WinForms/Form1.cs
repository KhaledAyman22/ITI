namespace D11_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //this.BackColor = Color.Lime;

            ///event Registration
            this.ResizeEnd += (sender, e) => this.Opacity = 1;
        }

        /// <summary>
        /// override Base OnEventName Method
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);

            this.Opacity = 0.75;
        }

        private void DemoCallBackMethod(object sender, EventArgs e)
        {
            this.Text = "Button Clicked";
        }
    }
}