using System;
using System.Drawing;
using System.Windows.Forms;

namespace OverlappingSquaresApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(this.Form1_Paint);
            this.DoubleBuffered = true; // ��������� �������� ��� ����������
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int size = 100; // ������ ������� ��������
            int step = 20;  // �������� ��� ������� ���������� ��������
            int count = 5;  // ���������� ���������

            for (int i = 0; i < count; i++)
            {
                g.DrawRectangle(Pens.Black, step * i, step * i, size, size);
                size -= 10; // ��������� ������ ������� ���������� ��������
            }
        }
    }
}

