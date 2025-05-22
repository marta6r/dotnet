using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CustomButtonsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateCustomButtons();
        }

        private void CreateCustomButtons()
        {
            // ����������� ������
            Button triangleButton = new Button();
            triangleButton.Text = "�����������";
            triangleButton.Location = new Point(50, 50);
            triangleButton.Size = new Size(100, 100);
            triangleButton.Region = new Region(new GraphicsPath(new PointF[] {
                new PointF(50, 0), new PointF(100, 100), new PointF(0, 100)
            }, new byte[] { 1, 1, 1 }));

            // ������� ������
            Button circleButton = new Button();
            circleButton.Text = "����";
            circleButton.Location = new Point(200, 50);
            circleButton.Size = new Size(100, 100);
            circleButton.Region = new Region(new Rectangle(0, 0, 100, 100));

            // ������-�������� (��������)
            Button pyramidButton = new Button();
            pyramidButton.Text = "��������";
            pyramidButton.Location = new Point(350, 50);
            pyramidButton.Size = new Size(100, 100);
            pyramidButton.Region = new Region(new GraphicsPath(new PointF[] {
                new PointF(50, 0), new PointF(100, 50), new PointF(75, 100), new PointF(25, 100), new PointF(0, 50)
            }, new byte[] { 1, 1, 1, 1, 1 }));

            // ���������� ������ �� �����
            this.Controls.Add(triangleButton);
            this.Controls.Add(circleButton);
            this.Controls.Add(pyramidButton);
        }
    }
}

