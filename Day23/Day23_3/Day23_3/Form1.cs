using System;
using System.Drawing;
using System.Windows.Forms;

namespace Day23_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Переопределяем метод OnPaint для рисования домика
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Крыша (треугольник)
            Point[] roof = { new Point(100, 50), new Point(50, 100), new Point(150, 100) };
            g.FillPolygon(Brushes.Brown, roof);

            // Стены (прямоугольник)
            g.FillRectangle(Brushes.Beige, 50, 100, 100, 100);

            // Окно (маленький прямоугольник)
            g.FillRectangle(Brushes.Blue, 70, 120, 20, 20);

            // Дверь (прямоугольник)
            g.FillRectangle(Brushes.DarkRed, 110, 150, 30, 50);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Здесь можно добавить настройки при загрузке формы
        }
    }
}
