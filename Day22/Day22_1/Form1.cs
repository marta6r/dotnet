using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace Day22_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender,
    EventArgs e)
        {
            // ��������� �������� X
            textBox1.Text = "3,4";
            // ��������� �������� Y
            textBox2.Text = "0,74";
            // ��������� �������� Z
            textBox3.Text = "19,43";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // ���������� �������� X
            double x = double.Parse(textBox1.Text);
            // ����� �������� X � ����
            textBox4.Text += Environment.NewLine + "X = " + x.ToString();
            // ���������� �������� Y
            double y = double.Parse(textBox2.Text);
            // ����� �������� Y � ����
            textBox4.Text += Environment.NewLine +
            "Y = " + y.ToString();
            // ���������� �������� Z
            double z = double.Parse(textBox3.Text);
            // ����� �������� Z � ����
            textBox4.Text += Environment.NewLine +
            "Z = " + z.ToString();
            // ��������� �������������� ���������
            double a = Math.Tan(x + y) *
            Math.Tan(x + y);
            double b = Math.Exp(y - z);
            double c = Math.Sqrt(Math.Cos(x * x) +
            Math.Sin(z * z));
            double u = a - b * c;
            // ������� ��������� � ����
            textBox4.Text += Environment.NewLine +
            "��������� U = " + u.ToString();
        }
    }
}