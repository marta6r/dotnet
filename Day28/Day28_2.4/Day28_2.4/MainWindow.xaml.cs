using System;
using System.Windows;
using System.Windows.Media;

namespace WPFChessBoard
{
    public partial class MainWindow : Window
    {
        private const int tileSize = 50; // Размер клетки
        private const int boardSize = 8; // Размер доски (8x8)

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
                Brush whiteBrush = Brushes.White;
                Brush blackBrush = Brushes.Black;

                for (int row = 0; row < boardSize; row++)
                {
                    for (int col = 0; col < boardSize; col++)
                    {
                        Brush brush = (row + col) % 2 == 0 ? whiteBrush : blackBrush;
                        dc.DrawRectangle(brush, null, new Rect(col * tileSize, row * tileSize, tileSize, tileSize));
                    }
                }

                // Рамка доски
                dc.DrawRectangle(null, new Pen(Brushes.Black, 2), new Rect(0, 0, boardSize * tileSize, boardSize * tileSize));
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

