using System;
using System.Collections.Generic;
using Car_Management;
using MySql.Data.MySqlClient;

namespace CarManagement
{
    public class DBHelper
    {
        private readonly DBConnection db;

        public DBHelper()
        {
            db = new DBConnection();
        }

        public void CreateTables()
        {
            List<string> commands = new List<string>();

            commands.Add("CREATE TABLE Cars (" +
            "plate PRIMARY KEY," +
            "mileage NOT NULL," +
            "year NOT NULL," +
            "model NULL," +
            "owner TEXT NULL," +
            "brand NOT NULL," +
            "FOREIGN KEY(owner) REFERENCES users(Owners)," +
            "FOREIGN KEY(brand) REFERENCES subreddits(Brands));");

            commands.Add("CREATE TABLE Cars (" +
            "plate PRIMARY KEY," +
            "mileage NOT NULL," +
            "year NOT NULL," +
            "model NULL," +
            "owner TEXT NULL," +
            "brand NOT NULL," +
            "FOREIGN KEY(owner) REFERENCES users(Owners)," +
            "FOREIGN KEY(brand) REFERENCES subreddits(Brands));");
        }

        public void ExecuteQueries(List<string> queries)
        {
            foreach (string query in queries)
            {
                var cmd = new MySqlCommand(query, db.Connection);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
