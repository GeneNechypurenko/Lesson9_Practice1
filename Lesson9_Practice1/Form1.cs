using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Lesson9_Practice1
{
    //Создайте приложение Windows Forms, которое будет рисовать случайные
    //    окружности разного цвета и размера на форме при щелчке мыши.
    //    Каждый раз, когда пользователь щелкает мышью на форме, будет
    //    рисоваться новая окружность случайного цвета и размера.
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Size = new(500, 500);
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            Random rnd = new();
            int size = rnd.Next(0, 100);
            int x = e.X - size / 2;
            int y = e.Y - size / 2;

            int red = rnd.Next(0, 255);
            int green = rnd.Next(0, 255);
            int blue = rnd.Next(0, 255);

            Color color = Color.FromArgb(red, green, blue);

            Graphics g = this.CreateGraphics();

            g.DrawEllipse(new Pen(color, 5), x, y, size, size);

            g.Dispose();
        }
    }
}