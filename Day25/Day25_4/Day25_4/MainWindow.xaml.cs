using System;
using System.Windows;
using System.Windows.Controls;

namespace ButtonApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CreateButton(); // Создаём первую кнопку
        }

        private void CreateButton()
        {
            Button button = new Button
            {
                Content = "Я кнопка",
                Width = 100,
                Height = 40,
                Margin = new Thickness(10)
            };

            button.MouseEnter += Button_MouseEnter; // Создание новой кнопки при наведении
            button.Click += Button_Click; // Удаление кнопки при клике

            MainGrid.Children.Add(button);
        }

        private void Button_MouseEnter(object sender, RoutedEventArgs e)
        {
            CreateButton(); // Создаём новую кнопку
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                MainGrid.Children.Remove(button); // Удаляем нажатую кнопку
            }
        }
    }
}

