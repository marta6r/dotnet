using System;
using System.Drawing;
using System.Windows.Forms;

public class SineWaveAnimation : Form
{
    private System.Windows.Forms.Timer timer;
    private int centerX, centerY;
    private double t; // Параметр времени

    public SineWaveAnimation()
    {
        this.Width = 800;
        this.Height = 400;
        this.Text = "Движение окружности по синусоиде";
        this.DoubleBuffered = true;

        centerX = 50; // Начальная x-координата круга
        centerY = this.ClientSize.Height / 2;

        timer = new System.Windows.Forms.Timer();
        timer.Interval = 30; // Скорость обновления
        timer.Tick += Timer_Tick;
        timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        t += 0.1; // Увеличиваем параметр движения
        this.Invalidate(); // Обновляем форму
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;

        g.Clear(Color.White);

        // Вычисляем текущие координаты круга
        int x = centerX + (int)(t * 50); // Двигаем по X
        int y = centerY + (int)(50 * Math.Sin(t)); // Двигаем по Y (синусоида)

        // Рисуем окружность
        g.FillEllipse(Brushes.Blue, x - 15, y - 15, 30, 30);
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new SineWaveAnimation());
    }
}
