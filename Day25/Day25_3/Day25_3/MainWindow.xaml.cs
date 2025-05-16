using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace GraphPlotter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonPlot_Click(object sender, RoutedEventArgs e)
        {
            double h;
            if (!double.TryParse(textBoxStep.Text, out h) || h <= 0)
            {
                MessageBox.Show("Введите корректный шаг!");
                return;
            }

            canvasGraph.Children.Clear();
            DrawAxes();
            PlotFunction(h);
        }

        private void DrawAxes()
        {
            Line xAxis = new Line { X1 = 50, X2 = 650, Y1 = 200, Y2 = 200, Stroke = Brushes.Black, StrokeThickness = 2 };
            Line yAxis = new Line { X1 = 350, X2 = 350, Y1 = 50, Y2 = 350, Stroke = Brushes.Black, StrokeThickness = 2 };
            canvasGraph.Children.Add(xAxis);
            canvasGraph.Children.Add(yAxis);
        }

        private void PlotFunction(double h)
        {
            for (double x = -Math.PI / 2 + h; x < Math.PI / 2; x += h)
            {
                double y = Math.Cos(x) / Math.Sin(x);
                double screenX = 350 + x * 50;
                double screenY = 200 - y * 50;

                Ellipse point = new Ellipse { Width = 5, Height = 5, Fill = Brushes.Red };
                Canvas.SetLeft(point, screenX);
                Canvas.SetTop(point, screenY);
                canvasGraph.Children.Add(point);
            }
        }
    }
}
