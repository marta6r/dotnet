using System;
using System.Drawing;
using System.Windows.Forms;

namespace Day29_2
{
    public partial class Form1 : Form
    {
        // ���������� ����������
        private int x1, y1, x2, y2, r;
        private double a;
        private Pen pen = new Pen(Color.DarkRed, 2);
        private System.Windows.Forms.Timer timer1; // ��������� ������������� Windows Forms Timer

        public Form1()
        {
            InitializeComponent();

            // ������ ������ � ����������� ���
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 100; // ���������� ������ 100 �� (10 ��� � �������)
            timer1.Tick += Timer1_Tick;
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            r = 150; // ������ �������
            a = 0; // ��������� ����

            // ���������� ����� ����� - ������ �������
            x1 = ClientSize.Width / 2;
            y1 = ClientSize.Height / 2;

            // ����� �������
            x2 = x1 + (int)(r * Math.Cos(a));
            y2 = y1 - (int)(r * Math.Sin(a));
        }

        private void Timer1_Tick(object? sender, EventArgs e) // ��������� NULL ��� sender
        {
            a = DateTime.Now.Second * 6 * Math.PI / 180; // ������ ������� � 6 ��������

            // ����� ���������� ����� �������
            x2 = x1 + (int)(r * Math.Cos(a));
            y2 = y1 - (int)(r * Math.Sin(a));

            // ��������� �����
            Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // ������ ��������� �������
            g.DrawLine(pen, x1, y1, x2, y2);
        }
    }
}

