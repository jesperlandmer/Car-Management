using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data.MySqlClient;

namespace CarManagement.model
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

            commands.Add("CREATE TABLE IF NOT EXISTS Owners (" +
            "ssn VARCHAR(10) PRIMARY KEY," +
            "birth DATETIME NULL," +
            "name VARCHAR(100) NULL) ENGINE = INNODB;");
            commands.Add("CREATE TABLE IF NOT EXISTS Models (" +
            "model VARCHAR(50) PRIMARY KEY," +
            "manufacturer VARCHAR(50) NULL) ENGINE = INNODB;");
            commands.Add("CREATE TABLE IF NOT EXISTS Cars (" +
            "plate VARCHAR(6) PRIMARY KEY," +
            "mileage INT NULL," +
            "year INT(4) NULL," +
            "model VARCHAR(50) NOT NULL," +
            "owner VARCHAR(10) NOT NULL," +
            "FOREIGN KEY(owner) REFERENCES Owners(ssn)," +
            "FOREIGN KEY(model) REFERENCES Models(model)) ENGINE = INNODB;");

            ExecuteQueries(commands);
        }

        public void InsertCar(Car car)
        {
            List<string> commands = new List<string>();

            commands.Add("INSERT IGNORE INTO Owners(ssn, birth, name) " +
            "VALUES('" + car.Owner.SSN + "', '" + car.Owner.BirthDate + "', '" + car.Owner.Name + "');");
            commands.Add("INSERT IGNORE INTO Models(model, manufacturer) " +
            "VALUES('" + car.Model.ModelName + "', '" + car.Model.Manufacturer + "');");
            commands.Add("INSERT IGNORE INTO Cars(plate, mileage, year, model, owner) " +
            "VALUES('" + car.Plate + "', " + car.Mileage + ", " + car.Year + ", '" + car.Model.ModelName + "', '" +
            car.Owner.SSN + "');");

            ExecuteQueries(commands);
        }

        public void RemoveCar(Car car)
        {
            List<string> commands = new List<string>();
            commands.Add("DELETE FROM Cars WHERE plate = '" + car.Plate + "';");
            ExecuteQueries(commands);
        }


        public void ExecuteQueries(List<string> queries)
        {
            db.Open();

            foreach (string query in queries)
            {
                var cmd = new MySqlCommand(query, db.Connection);
                cmd.ExecuteNonQuery();
            }

            db.Close();
        }
        public List<KeyValuePair<string, string>> ReadDB(string query, List<string> attr)
        {
            db.Open();

            List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>();
            var cmd = new MySqlCommand(query, db.Connection);

            using (MySqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    foreach (var a in attr)
                    {
                        kvpList.Insert(0, new KeyValuePair<string, string>(a, dr[a].ToString()));
                    }
                }
            }

            db.Close();

            return kvpList;
        }
    }
}
