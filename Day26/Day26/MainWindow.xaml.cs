using System;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

namespace XMLParking
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoadXml(object sender, RoutedEventArgs e)
        {
            XDocument xmlDoc = XDocument.Load("XMLFile1.xml");
            CarList.Items.Clear();
            foreach (var car in xmlDoc.Descendants("Автомобиль"))
            {
                CarList.Items.Add($"Марка: {car.Element("Марка")?.Value}, Год выпуска: {car.Element("ГодВыпуска")?.Value}, Срок аренды: {car.Element("СрокАренды")?.Value} дней");
            }
        }
    }
}
