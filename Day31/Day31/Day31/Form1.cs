using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Day31
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=localhost;Database=bdtur_firm;Uid=root;Pwd=;";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DeleteTour(4);
            LoadData(); // ��������� ������ ��� ������� �����

        }

        public void LoadData()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT * FROM tour";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    adapter.Fill(dataTable);
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("������: " + ex.Message);
                }
            }
        }

        private void DeleteTour(int tourId)
        {
            string connectionString = "server=localhost;user=root;password=;database=bdtur_firm;";
            string query = "DELETE FROM tour WHERE id_tour = 1";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", tourId);

                    int affectedRows = cmd.ExecuteNonQuery(); // �����: ExecuteNonQuery ��� DELETE

                    if (affectedRows > 0)
                        MessageBox.Show("��� ������� �����");
                    else
                        MessageBox.Show("��� � ����� ID �� ������");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("������ ��� �������� ����: " + ex.Message);
                }
            }
        }

        public void AddTourist(int id_tourist, string surname, string name, string middle_name)
        {
            string connectionString = "server=localhost;user=root;password=;database=bdtur_firm;";

            string query = "INSERT INTO tourists (id_tourist, surname, name, middle_name) VALUES (@id_tourist, @surname, @name, @middle_name)";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_tourist", id_tourist);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@middle_name", middle_name);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("������ ������� ��������");
                    else
                        MessageBox.Show("������ ��� ���������� �������");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("������ ���� ������: " + ex.Message);
                }
            }
        }


        public void UpdateTourist(int id_tourist, string surname, string name, string middle_name)
        {
            string connectionString = "server=localhost;user=root;password=;database=bdtur_firm;";

            string query = "UPDATE tourists SET surname = @surname, name = @name, middle_name = @middle_name WHERE id_tourist = @id_tourist";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_tourist", id_tourist);
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@middle_name", middle_name);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("������ ������� ������� ���������");
                    else
                        MessageBox.Show("������ � ����� ID �� ������");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("������ ���� ������: " + ex.Message);
                }
            }
        }



    }
}

