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
            // Настройка формы
            this.Width = 400;
            this.Height = 600;
            this.DoubleBuffered = true; // Двойная буферизация для плавной анимации
            this.Text = "Анимация взлёта ракеты";

            // Инициализация кнопки запуска
            startButton = new Button();
            startButton.Text = "Старт";
            startButton.BackColor = Color.Red;
            startButton.ForeColor = Color.White;
            startButton.Width = 100;
            startButton.Height = 40;
            startButton.Location = new Point((this.ClientSize.Width - startButton.Width) / 2, this.ClientSize.Height - 60);
            startButton.Click += StartButton_Click;
            this.Controls.Add(startButton);

            // Инициализация таймера
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 30; // Интервал обновления (мс)
            timer.Tick += Timer_Tick;

            // Начальная позиция ракеты (внизу формы)
            rocketY = this.ClientSize.Height - 120;
            isFlying = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Старт анимации!");
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (!isFlying)
            {
                isFlying = true;
                rocketY = this.ClientSize.Height - 120; // Сброс позиции ракеты
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            // Поднимаем ракету вверх
            rocketY -= 5;

            // Если ракета вышла за верхнюю границу, останавливаем анимацию
            if (rocketY < -100)
            {
                timer.Stop();
                isFlying = false;
            }

            // Перерисовываем форму
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            // Рисуем фон (небо)
            g.Clear(Color.Black);

            // Рисуем ракету (упрощённый вариант)
            int rocketX = (this.ClientSize.Width - 40) / 2;

            // Тело ракеты
            Rectangle body = new Rectangle(rocketX, rocketY, 40, 100);
            g.FillRectangle(Brushes.Gray, body);

            // Коническая верхушка
            Point[] nose = {
            new Point(rocketX, rocketY),
            new Point(rocketX + 20, rocketY - 40),
            new Point(rocketX + 40, rocketY)
        };
            g.FillPolygon(Brushes.Red, nose);

            // Окна ракеты
            g.FillEllipse(Brushes.LightBlue, rocketX + 10, rocketY + 20, 20, 20);
            g.FillEllipse(Brushes.LightBlue, rocketX + 10, rocketY + 60, 20, 20);

            // Пламя двигателя при взлёте
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



