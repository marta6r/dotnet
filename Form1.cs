namespace Day28_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            // Далее вставляется код рисования
            g.Clear(Color.White);
            for (int i = 0; i < 50; i++)
                g.DrawLine(new Pen(Brushes.Black, 2),
                10, 4 * i + 20, 200, 4 * i + 20);
        }
    }
}
