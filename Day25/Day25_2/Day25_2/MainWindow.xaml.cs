using System;
using System.Windows;

namespace HelloApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonSayName_Click(object sender, RoutedEventArgs e)
        {
            string name = string.IsNullOrWhiteSpace(textBoxName.Text) ? "World" : textBoxName.Text;
            textBlockHello.Text = $"Hello {name}!";
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void buttonHelp_Click(object sender, RoutedEventArgs e)
        {
            AboutWindow about = new AboutWindow();
            about.ShowDialog();
        }
    }
}
