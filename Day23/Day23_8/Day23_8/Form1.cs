

using System;
using System.Linq;
using System.Windows.Forms;

namespace Day23_8
{
    public partial class Form1 : Form
    {
        private int[,] matrix = new int[4, 3];

        public Form1()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            dataGridViewMatrix.RowCount = 4;
            dataGridViewMatrix.ColumnCount = 3;

            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    matrix[i, j] = rand.Next(1, 100); // Числа от 1 до 99
                    dataGridViewMatrix.Rows[i].Cells[j].Value = matrix[i, j];
                }
            }
        }

        private void btnFindMax_Click(object sender, EventArgs e)
        {
            int maxElement = matrix.Cast<int>().Max();
            txtResult.Text = $"Максимальный элемент: {maxElement}";
        }
    }
}
