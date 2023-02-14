using System.Drawing;
using System.Drawing.Drawing2D;



namespace Task_4
{
    public partial class Form1 : Form
    {
        Point prev;
        
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.None;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath graphicsPath = new();
            graphicsPath.AddEllipse(0, 0, 200, 200);
            graphicsPath.AddEllipse(ClientSize.Width - 200, 0, 200, 200);
            
            e.Graphics.FillPath(Brushes.Black, graphicsPath);
            
            graphicsPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            graphicsPath.FillMode = FillMode.Winding;
            
            Region = new Region(graphicsPath);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                Location = new Point(Location.X + e.X - prev.X, Location.Y + e.Y - prev.Y);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            prev = e.Location;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}