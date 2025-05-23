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

            // Используем конструкцию using для автоматического закрытия соединения
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open(); // Открываем соединение

                    // Создаем SQL-команду для выборки данных из таблицы
                    MySqlCommand cmd = new MySqlCommand("DELETE FROM tours WHERE id_tour = 1;", conn);

                    // Выполняем команду и получаем ридер для чтения данных
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        // Читаем построчно данные из результата запроса
                        while (reader.Read())
                        {
                            // Пример: выводим значение первого столбца текущей строки
                            Console.WriteLine(reader.GetString(0));
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    // Обработка ошибок подключения или выполнения запроса
                    Console.WriteLine("Ошибка базы данных: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // Общая обработка ошибок
                    Console.WriteLine("Ошибка: " + ex.Message);
                }
            }
        }
    }
}