namespace Task_5
{
    public partial class Form1 : Form
    {
        Rectangle ball = new(100, 310, 100, 100);
        bool direction = false;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawEllipse(Pens.Black, new(10,0, 100, 100));
            e.Graphics.DrawLine(Pens.Black, new(60,100), new(60,350));
            e.Graphics.DrawLine(Pens.Black, new(60, 150), new(30, 180));
            e.Graphics.DrawLine(Pens.Black, new(60, 150), new(90, 180));
            e.Graphics.DrawLine(Pens.Black, new(60, 350), new(30, 380));
            e.Graphics.DrawLine(Pens.Black, new(60, 350), new(90, 380));

            e.Graphics.DrawEllipse(Pens.Black, new(600, 0, 100, 100));
            e.Graphics.DrawLine(Pens.Black, new(650, 100), new(650, 350));
            e.Graphics.DrawLine(Pens.Black, new(650, 150), new(620, 180));
            e.Graphics.DrawLine(Pens.Black, new(650, 150), new(680, 180));
            e.Graphics.DrawLine(Pens.Black, new(650, 350), new(620, 380));
            e.Graphics.DrawLine(Pens.Black, new(650, 350), new(680, 380));

        }

        private void Move(object sender, EventArgs e)
        {
            Graphics graphics = CreateGraphics();
            graphics.FillEllipse(new SolidBrush(BackColor), ball);
            graphics.DrawEllipse(new Pen(BackColor), ball);


            if (ball.X == 500) direction = true;

            if (ball.X == 100) direction = false;

            if (direction)
                ball = new(ball.X - 50, ball.Y, 100, 100);
            else
                ball = new(ball.X + 50, ball.Y, 100, 100);

            graphics.FillEllipse(Brushes.Red, ball);
            graphics.DrawEllipse(Pens.Black, ball);

        }
    }
}