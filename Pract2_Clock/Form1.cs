using System;

namespace Pract2_Clock
{
    public partial class Form1 : Form
    {
        System.Windows.Forms.Timer timer = new();
        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(400, 400);

            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e) => Refresh();

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            float x = Width / 2;
            float y = Height / 2;
            int r = Width / 2 - 100;

            DateTime currentTime = DateTime.Now;

            g.DrawEllipse(new Pen(Brushes.Black, 10), x - r, y - r, 2 * r, 2 * r);

            float hour = (360 / 12) * (currentTime.Hour % 12) + (360 / 12) * (currentTime.Minute / 60f);
            float minute = (360 / 60) * currentTime.Minute;
            float second = (360 / 60) * currentTime.Second;

            g.DrawEllipse(new Pen(Brushes.Black, 10), x - r, y - r, 2 * r, 2 * r);

            DrowHand(g, x, y, r / 2, hour, Brushes.Black, 8);
            DrowHand(g, x, y, r - 30, minute, Brushes.Black, 8);
            DrowHand(g, x, y, r - 20, second, Brushes.Red, 4);
        }

        private void DrowHand(Graphics g, float x, float y, float length, float angleDegrees, Brush brush, float width)
        {
            float angleRadians = angleDegrees * (float)Math.PI / 180;

            float centerX = x + length * (float)Math.Sin(angleRadians);
            float centerY = y - length * (float)Math.Cos(angleRadians);

            g.DrawLine(new Pen(brush, width), centerX, centerY, x, y);
        }
    }
}