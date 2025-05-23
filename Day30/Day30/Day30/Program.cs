using MySql.Data.MySqlClient;

namespace Day30
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());

            string connectionString = "server=localhost;port=3306;user=root;password=;database=bdtur_firm;";

            // ���������� ����������� using ��� ��������������� �������� ����������
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open(); // ��������� ����������

                    // ������� SQL-������� ��� ������� ������ �� �������
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM tours WHERE id_tour = 1;", conn);

                    // ��������� ������� � �������� ����� ��� ������ ������
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // ������ ��������� ������ �� ���������� �������
                        while (reader.Read())
                        {
                            // ������: ������� �������� ������� ������� ������� ������
                            Console.WriteLine(reader.GetString(0));
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // ��������� ������ ����������� ��� ���������� �������
                    Console.WriteLine("������ ���� ������: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // ����� ��������� ������
                    Console.WriteLine("������: " + ex.Message);
                }
            }
        }
    }
}