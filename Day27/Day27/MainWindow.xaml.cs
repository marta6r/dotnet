using System.Windows;
using System.Windows.Controls;

namespace XmlTaskWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            PopulateData();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (ListTextBox == null || ListTreeView == null || ListListBox == null) return;

            ListTextBox.Visibility = TextBlockOption.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            ListTreeView.Visibility = TreeViewOption.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
            ListListBox.Visibility = ListBoxOption.IsChecked == true ? Visibility.Visible : Visibility.Collapsed;
        }

        private void PopulateData()
        {
            if (ListTextBox == null || ListTreeView == null || ListListBox == null) return;

            string[] countries = { "Россия", "Беларусь", "Казахстан", "Узбекистан" };

            // Вывод в TextBox
            ListTextBox.Text = string.Join("\n", countries);

            // Заполнение ListBox и TreeView
            foreach (var country in countries)
            {
                ListListBox.Items.Add(country);
                ListTreeView.Items.Add(new TreeViewItem { Header = country });
            }
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Поиск: {FindTextBox.Text}");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"Удаление: {DeleteTextBox.Text}");
        }
    }
}
