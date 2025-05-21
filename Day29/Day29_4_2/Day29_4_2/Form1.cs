using System;
using System.Drawing;
using System.Windows.Forms;

public class ClockForm : Form
{
    private System.Windows.Forms.Timer timer;
    private int centerX, centerY, radius;
    private double angle;

    public ClockForm()
    {
        // Настройки формы
        this.Width = 400;
        this.Height = 400;
        this.Text = "Clock - Секундная стрелка";
        this.DoubleBuffered = true;

        // Определение центра и радиуса циферблата
        centerX = this.ClientSize.Width / 2;
        centerY = this.ClientSize.Height / 2;
        radius = 100;

        // Инициализация таймера
        timer = new System.Windows.Forms.Timer();
        timer.Interval = 1000; // Обновление каждую секунду
        timer.Tick += Timer_Tick;
        timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        angle = DateTime.Now.Second * 6 * Math.PI / 180; // Каждая секунда = 6 градусов
        this.Invalidate(); // Перерисовка формы
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;

        // Рисуем циферблат
        g.DrawEllipse(Pens.Black, centerX - radius, centerY - radius, radius * 2, radius * 2);

        // Вычисление конца секундной стрелки
        int x2 = centerX + (int)(radius * Math.Cos(angle - Math.PI / 2));
        int y2 = centerY + (int)(radius * Math.Sin(angle - Math.PI / 2));

        // Рисуем секундную стрелку
        g.DrawLine(new Pen(Color.Red, 2), centerX, centerY, x2, y2);
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new ClockForm());
    }
}

