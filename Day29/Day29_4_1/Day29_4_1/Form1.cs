using System;
using System.Drawing;
using System.Windows.Forms;
namespace Day29_4_1
{
    public class RocketForm : Form
    {
        private Button startButton;
        private System.Windows.Forms.Timer timer;
        private int rocketY;
        private bool isFlying;

        public RocketForm()
        {
            // ��������� �����
            this.Width = 400;
            this.Height = 600;
            this.DoubleBuffered = true; // ������� ����������� ��� ������� ��������
            this.Text = "�������� ����� ������";

            // ������������� ������ �������
            startButton = new Button();
            startButton.Text = "�����";
            startButton.BackColor = Color.Red;
            startButton.ForeColor = Color.White;
            startButton.Width = 100;
            startButton.Height = 40;
            startButton.Location = new Point((this.ClientSize.Width - startButton.Width) / 2, this.ClientSize.Height - 60);
            startButton.Click += StartButton_Click;
            this.Controls.Add(startButton);

            // ������������� �������
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 30; // �������� ���������� (��)
            timer.Tick += Timer_Tick;

            // ��������� ������� ������ (����� �����)
            rocketY = this.ClientSize.Height - 120;
            isFlying = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("����� ��������!");
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!isFlying)
            {
                isFlying = true;
                rocketY = this.ClientSize.Height - 120; // ����� ������� ������
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // ��������� ������ �����
            rocketY -= 5;

            // ���� ������ ����� �� ������� �������, ������������� ��������
            if (rocketY < -100)
            {
                timer.Stop();
                isFlying = false;
            }

            // �������������� �����
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // ������ ��� (����)
            g.Clear(Color.Black);

            // ������ ������ (���������� �������)
            int rocketX = (this.ClientSize.Width - 40) / 2;

            // ���� ������
            Rectangle body = new Rectangle(rocketX, rocketY, 40, 100);
            g.FillRectangle(Brushes.Gray, body);

            // ���������� ��������
            Point[] nose = {
            new Point(rocketX, rocketY),
            new Point(rocketX + 20, rocketY - 40),
            new Point(rocketX + 40, rocketY)
        };
            g.FillPolygon(Brushes.Red, nose);

            // ���� ������
            g.FillEllipse(Brushes.LightBlue, rocketX + 10, rocketY + 20, 20, 20);
            g.FillEllipse(Brushes.LightBlue, rocketX + 10, rocketY + 60, 20, 20);

            // ����� ��������� ��� �����
            if (isFlying)
            {
                Point[] flame = {
                new Point(rocketX + 10, rocketY + 100),
                new Point(rocketX + 20, rocketY + 130),
                new Point(rocketX + 30, rocketY + 100)
            };
                g.FillPolygon(Brushes.OrangeRed, flame);
                g.FillPolygon(Brushes.Yellow, new Point[]
                {
                new Point(rocketX + 15, rocketY + 100),
                new Point(rocketX + 20, rocketY + 120),
                new Point(rocketX + 25, rocketY + 100)
                });
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new RocketForm());
        }
    }
}



