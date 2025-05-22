using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
                // Эллипс
                dc.DrawEllipse(Brushes.Transparent, new Pen(Brushes.Black, 2), new Point(100, 50), 50, 30);

                // Закрашенный круг
                dc.DrawEllipse(Brushes.Blue, null, new Point(250, 50), 40, 40);

                // Закрашенный прямоугольник
                dc.DrawRectangle(Brushes.Green, null, new Rect(50, 150, 120, 80));

                // Треугольник
                StreamGeometry triangleGeometry = new StreamGeometry();
                using (StreamGeometryContext sgc = triangleGeometry.Open())
                {
                    sgc.BeginFigure(new Point(200, 150), true, true);
                    sgc.LineTo(new Point(250, 250), true, false);
                    sgc.LineTo(new Point(150, 250), true, false);
                }
                dc.DrawGeometry(null, new Pen(Brushes.Red, 2), triangleGeometry);

                // Сектор (часть круга)
                StreamGeometry sectorGeometry = new StreamGeometry();
                using (StreamGeometryContext sgc = sectorGeometry.Open())
                {
                    sgc.BeginFigure(new Point(350, 150), true, true);
                    sgc.ArcTo(new Point(450, 250), new Size(100, 100), 0, false, SweepDirection.Clockwise, true, false);
                    sgc.LineTo(new Point(350, 150), true, false);
                }
                dc.DrawGeometry(Brushes.Orange, null, sectorGeometry);
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

