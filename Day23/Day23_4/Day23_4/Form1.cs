using System;
using System.Drawing;
using System.Windows.Forms;

namespace DynamicControlsApp
{
    public partial class Form1 : Form
    {
        private TextBox inputType;
        private TextBox inputX;
        private TextBox inputY;
        private Button createButton;

        public Form1()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            // ���� ����� ���� ��������
            inputType = new TextBox { Location = new Point(20, 20), Width = 50 };
            this.Controls.Add(inputType);

            // ���� ����� ���������� X
            inputX = new TextBox { Location = new Point(80, 20), Width = 50 };
            this.Controls.Add(inputX);

            // ���� ����� ���������� Y
            inputY = new TextBox { Location = new Point(140, 20), Width = 50 };
            this.Controls.Add(inputY);

            // ������ �������� ��������
            createButton = new Button { Text = "�������", Location = new Point(200, 20) };
            createButton.Click += CreateElement;
            this.Controls.Add(createButton);
        }

        private void CreateElement(object sender, EventArgs e)
        {
            if (!int.TryParse(inputX.Text, out int x) || !int.TryParse(inputY.Text, out int y))
            {
                MessageBox.Show("������� ���������� ����������!");
                return;
            }

            Control newControl = null;
            switch (inputType.Text.ToUpper())
            {
                case "�":
                    newControl = new Button { Text = "������", BackColor = Color.LightBlue, Size = new Size(80, 30) };
                    break;
                case "�":
                    newControl = new TextBox { BackColor = Color.LightYellow, Size = new Size(100, 30) };
                    break;
                case "�":
                    newControl = new Label { Text = "�����", BackColor = Color.LightGreen, AutoSize = true };
                    break;
                default:
                    MessageBox.Show("������� �, � ��� �!");
                    return;
            }

            newControl.Location = new Point(x, y);
            newControl.MouseEnter += (s, ev) => this.Controls.Remove((Control)s);
            this.Controls.Add(newControl);
        }

        private void InitializeComponent()
        {
            this.ClientSize = new Size(400, 300);
            this.Text = "������������ �������� ���������";
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
