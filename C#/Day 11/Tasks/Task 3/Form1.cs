using System.Drawing;

namespace Task_3
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private bool isInside = false;
        Rectangle rectangle = new(20, 10, 200, 100);

        public Form1()
        {
            InitializeComponent();
            graphics = CreateGraphics();
        }


        protected override void OnPaint(PaintEventArgs e)
        {

            e.Graphics.FillRectangle(Brushes.Red, rectangle);
            e.Graphics.DrawRectangle(Pens.Black, rectangle);

            base.OnPaint(e);
        }

        private void winMouseDown(object sender, MouseEventArgs e)
        {
            if(rectangle.Contains(e.Location))
            {
                isInside = true;
            }

        }

        private void winMouseUp(object sender, MouseEventArgs e)
        {
            if (isInside)
            {
                Invalidate();
                rectangle = new(e.X, e.Y, 200, 100);
                graphics.FillRectangle(Brushes.Red, rectangle);
                graphics.DrawRectangle(Pens.Black, rectangle);
            }
        }

    }
}