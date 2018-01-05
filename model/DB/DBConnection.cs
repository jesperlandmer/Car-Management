using System;
using MySql.Data.MySqlClient;

namespace CarManagement.model
{
    public class DBConnection
    {
        const string _server = "localhost";
        const int _port = 3306;
        const string _database = "car_management";
        const string _name = "root";
        const string _password = "yourpassword";
        private string _connString = string.Format("Server={0}; database={1}; UID={2}; password={3}",
                                          _server, _database, _name, _password);

        private readonly MySqlConnection connection;
        public MySqlConnection Connection
        {
            get { return connection; }
        }
        public string Database
        {
            get { return _database; }
        }
        public DBConnection()
        {
            CreateDatabase();
            connection = new MySqlConnection(_connString);
        }

        public void CreateDatabase()
        {
            String conStr = string.Format("Server={0}; database=mysql; UID={1}; password={2}",
                                          _server, _name, _password);
            String str = "CREATE DATABASE IF NOT EXISTS " + _database;
            MySqlConnection myConn = new MySqlConnection(conStr);

            myConn.Open();
            var cmd = new MySqlCommand(str, myConn);
            cmd.ExecuteNonQuery();
            myConn.Close();
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
