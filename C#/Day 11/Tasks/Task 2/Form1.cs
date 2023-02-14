using System.Windows.Forms;

namespace Task_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            color.Click += (sender, e) => ColorClick();
        }

        private Graphics graphics;
        private Pen lineColor = Pens.Black;
        private Point? previousPoint;
        private ColorDialog dlgColor = new();

        private void winMouseDown(object sender, MouseEventArgs e)
        {
            graphics = CreateGraphics();
            previousPoint = e.Location;

        }

        private void winMouseMove(object sender, MouseEventArgs e)
        {

            if (graphics != null)
            {
                Pen pen;
                if (e.Button == MouseButtons.Left) pen = lineColor;
                else pen = new Pen(BackColor);

                if (previousPoint != null)
                {
                    graphics.DrawLine(pen, (Point)previousPoint, e.Location);
                    previousPoint = e.Location;
                }
            }
        }

        private void winMouseUp(object sender, MouseEventArgs e)
        {
            if (graphics != null)
            {
                previousPoint = null;
            }
        }

        private void ColorClick()
        {
            if (dlgColor.ShowDialog() == DialogResult.OK)
                lineColor = new Pen(dlgColor.Color);
        }

    }
}