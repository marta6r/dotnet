using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConcentricCirclesApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(this.Form1_Paint);
            this.DoubleBuffered = true; // Устраняет мерцание при перерисовке
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Центр экрана
            int centerX = this.ClientSize.Width / 2;
            int centerY = this.ClientSize.Height / 2;

            // Радиусы окружностей
            int[] radii = { 50, 100, 150 };

            foreach (int radius in radii)
            {
                g.DrawEllipse(Pens.Black, centerX - radius, centerY - radius, radius * 2, radius * 2);
            }
        }
    }
}

