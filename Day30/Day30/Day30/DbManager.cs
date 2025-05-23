//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Day30
//{
//    internal class DbManager
//    {
//    }
//}

using MySql.Data.MySqlClient;

public class DbManager
{
    private MySqlConnection connection;

    public DbManager(string connectionString)
    {
        connection = new MySqlConnection(connectionString);
    }

    public void OpenConnection()
    {
        if (connection.State == System.Data.ConnectionState.Closed)
            connection.Open();
    }

    public void CloseConnection()
    {
        if (connection.State == System.Data.ConnectionState.Open)
            connection.Close();
    }

    public MySqlConnection GetConnection()
    {
        return connection;
    }
}
