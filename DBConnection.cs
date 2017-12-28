using System;
using MySql.Data.MySqlClient;

namespace Car_Management
{
    public class DBConnection
    {
        const string _server = "localhost";
        const string _database = "car_management";
        const string _name = "username";
        const string _password = "password";
        private string connstring = string.Format("Server={0}; database={1}; UID={2}; password={3}",
                                          _server, _database, _name, _password);
        private readonly MySqlConnection connection;

        public MySqlConnection Connection
        {
            get { return connection; }
        }

        public DBConnection()
        {
            connection = new MySqlConnection(connstring);
        }

        public void CreateDatabase()
        {
            string sql = "CREATE DATABASE IF NOT EXISTS '" + _database + "';";
            var cmd = new MySqlCommand(sql, connection);
            cmd.ExecuteNonQuery();
        }

        public void Open()
        {
            connection.Open();
        }     

        public void Close()
        {
            connection.Close();
        }       
    }
}
