using System;
using System.Drawing;
using System.Windows.Forms;

namespace Day28_1._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(this.Form1_Paint);
            this.DoubleBuffered = true; // Улучшает отображение без артефактов
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Эллипс
            g.DrawEllipse(Pens.Black, 50, 50, 100, 60);

            // Закрашенный круг
            g.FillEllipse(Brushes.Blue, 200, 50, 80, 80);

            // Закрашенный прямоугольник
            g.FillRectangle(Brushes.Green, 50, 150, 120, 80);

            // Треугольник
            Point[] trianglePoints = { new Point(200, 150), new Point(250, 250), new Point(150, 250) };
            g.DrawPolygon(Pens.Red, trianglePoints);

            // Сектор (часть круга)
            g.FillPie(Brushes.Orange, 300, 150, 100, 100, 0, 45);
        }
    }
}
