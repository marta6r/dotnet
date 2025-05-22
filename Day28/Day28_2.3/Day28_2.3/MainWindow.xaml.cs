using System;
using System.Windows;
using System.Windows.Media;

namespace WPFShapes
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DrawingVisual visual = new DrawingVisual();
            using (DrawingContext dc = visual.RenderOpen())
            {
                // Центр экрана
                Point center = new Point(this.Width / 2, this.Height / 2);

                // Радиусы окружностей
                int[] radii = { 50, 100, 150 };

                foreach (int radius in radii)
                {
                    dc.DrawEllipse(null, new Pen(Brushes.Black, 2), center, radius, radius);
                }
            }

            DrawingCanvas.Children.Add(new DrawingVisualHost(visual));
        }
    }

    public class DrawingVisualHost : FrameworkElement
    {
        private readonly DrawingVisual _visual;
        public DrawingVisualHost(DrawingVisual visual)
        {
            _visual = visual;
            this.AddVisualChild(_visual);
        }
        protected override int VisualChildrenCount => 1;
        protected override Visual GetVisualChild(int index) => _visual;
    }
}
