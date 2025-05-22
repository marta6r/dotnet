using System;
using System.Drawing;
using System.Windows.Forms;

namespace ChessBoardApp
{
    public partial class Form1 : Form
    {
        private const int tileSize = 50; // Размер клетки
        private const int boardSize = 8; // Размер доски (8x8)

        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(this.Form1_Paint);
            this.DoubleBuffered = true; // Устраняет мерцание
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush whiteBrush = Brushes.White;
            Brush blackBrush = Brushes.Black;

            for (int row = 0; row < boardSize; row++)
            {
                for (int col = 0; col < boardSize; col++)
                {
                    Brush brush = (row + col) % 2 == 0 ? whiteBrush : blackBrush;
                    g.FillRectangle(brush, col * tileSize, row * tileSize, tileSize, tileSize);
                }
            }

            // Рамка доски
            g.DrawRectangle(Pens.Black, 0, 0, boardSize * tileSize, boardSize * tileSize);
        }
    }
}
