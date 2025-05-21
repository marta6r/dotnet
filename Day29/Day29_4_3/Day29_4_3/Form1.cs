using System;
using System.Drawing;
using System.Windows.Forms;

public class SineWaveAnimation : Form
{
    private System.Windows.Forms.Timer timer;
    private int centerX, centerY;
    private double t; // �������� �������

    public SineWaveAnimation()
    {
        this.Width = 800;
        this.Height = 400;
        this.Text = "�������� ���������� �� ���������";
        this.DoubleBuffered = true;

        centerX = 50; // ��������� x-���������� �����
        centerY = this.ClientSize.Height / 2;

        timer = new System.Windows.Forms.Timer();
        timer.Interval = 30; // �������� ����������
        timer.Tick += Timer_Tick;
        timer.Start();
    }

    private void Timer_Tick(object sender, EventArgs e)
    {
        t += 0.1; // ����������� �������� ��������
        this.Invalidate(); // ��������� �����
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        Graphics g = e.Graphics;

        g.Clear(Color.White);

        // ��������� ������� ���������� �����
        int x = centerX + (int)(t * 50); // ������� �� X
        int y = centerY + (int)(50 * Math.Sin(t)); // ������� �� Y (���������)

        // ������ ����������
        g.FillEllipse(Brushes.Blue, x - 15, y - 15, 30, 30);
    }

    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new SineWaveAnimation());
    }
}
