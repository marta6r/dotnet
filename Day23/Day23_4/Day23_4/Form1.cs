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
            // Поле ввода типа элемента
            inputType = new TextBox { Location = new Point(20, 20), Width = 50 };
            this.Controls.Add(inputType);

            // Поле ввода координаты X
            inputX = new TextBox { Location = new Point(80, 20), Width = 50 };
            this.Controls.Add(inputX);

            // Поле ввода координаты Y
            inputY = new TextBox { Location = new Point(140, 20), Width = 50 };
            this.Controls.Add(inputY);

            // Кнопка создания элемента
            createButton = new Button { Text = "Создать", Location = new Point(200, 20) };
            createButton.Click += CreateElement;
            this.Controls.Add(createButton);
        }

        private void CreateElement(object sender, EventArgs e)
        {
            if (!int.TryParse(inputX.Text, out int x) || !int.TryParse(inputY.Text, out int y))
            {
                MessageBox.Show("Введите корректные координаты!");
                return;
            }

            Control newControl = null;
            switch (inputType.Text.ToUpper())
            {
                case "К":
                    newControl = new Button { Text = "Кнопка", BackColor = Color.LightBlue, Size = new Size(80, 30) };
                    break;
                case "П":
                    newControl = new TextBox { BackColor = Color.LightYellow, Size = new Size(100, 30) };
                    break;
                case "М":
                    newControl = new Label { Text = "Метка", BackColor = Color.LightGreen, AutoSize = true };
                    break;
                default:
                    MessageBox.Show("Введите К, П или М!");
                    return;
            }

            newControl.Location = new Point(x, y);
            newControl.MouseEnter += (s, ev) => this.Controls.Remove((Control)s);
            this.Controls.Add(newControl);
        }

        private void InitializeComponent()
        {
            this.ClientSize = new Size(400, 300);
            this.Text = "Динамическое создание элементов";
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new Form1());
        }
    }
}
