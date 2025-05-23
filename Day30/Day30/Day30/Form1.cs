namespace Day30
{
    using MySql.Data.MySqlClient;
    using System.Data;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            string connectionString = "server=localhost;user=root;password=;database=bdtur_firm;";
            string query = "SELECT * FROM tourists;";

            DataTable dt = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        dt.Load(reader);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("������ ��� �������� ������: " + ex.Message);
                    return;
                }
            }

            dataGridView1.DataSource = dt;
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


        public void AddTourist(string surname, string name, string middle_name)
        {
            string connectionString = "server=localhost;user=root;password=;database=bdtur_firm;";

            string query = "INSERT INTO tourists (surname, name, middle_name) VALUES (@surname, @name, @middle_name)";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conn);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData(); // ��������� ������ ��� �������� �����
            DeleteTour(1);
            AddTourist("Radivanovskaya2", "Marta2", "Victorovna2");
            UpdateTourist(1, "Radivanovskaya1", "Marta1", "Victorovna1");
        }

    }
}