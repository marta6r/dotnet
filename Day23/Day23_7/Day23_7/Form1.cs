using System;
using System.Linq;
using System.Windows.Forms;

namespace Day23_7
{
    public partial class Form1 : Form
    {
        private int[] A = new int[30];

        public Form1()
        {
            InitializeComponent();

        }
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // ������� ������
            listBoxArray.Items.Clear();

            // ��������� ��������� �����
            Random rand = new Random();
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = rand.Next(1, 100); // ����� �� 1 �� 99
                listBoxArray.Items.Add($"A[{i}] = {A[i]}");
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int sum = A.Where(x => x % 5 == 0).Sum();
            txtResult.Text = $"�����: {sum}";
        }
    }
}
