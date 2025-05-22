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
                int startX = 50, startY = 50, size = 100, step = 20;

                for (int i = 0; i < 5; i++) // Рисуем 5 квадратов
                {
                    dc.DrawRectangle(null, new Pen(Brushes.Black, 2), new Rect(startX, startY, size, size));
                    startX += step;
                    startY += step;
                    size -= 10;
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

