using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Day32
{
    public partial class Form1 : Form
    {
        // Строка подключения должна быть полем класса
        private string connectionString = "Server=localhost;Database=bdtur_firm;Uid=root;Pwd=;";

        private DataSet dataSet = new DataSet();
        private DataTable dataTable = new DataTable();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData(); // Загружаем данные при загрузке формы
        }

        public void LoadData()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM tourists";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    adapter.Fill(dataSet, "tourists");

                    dataTable = dataSet.Tables["tourists"];
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
        }
    }
}

