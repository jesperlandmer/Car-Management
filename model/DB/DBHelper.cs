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
            "birth DATETIME NOT NULL," +
            "name VARCHAR(100) NOT NULL) ENGINE = INNODB;");
            commands.Add("CREATE TABLE IF NOT EXISTS Manufacturers (" +
            "brand VARCHAR(50) PRIMARY KEY) ENGINE = INNODB;");
            commands.Add("CREATE TABLE IF NOT EXISTS Cars (" +
            "plate VARCHAR(6) PRIMARY KEY," +
            "mileage INT NOT NULL," +
            "year INT(4) NOT NULL," +
            "model VARCHAR(50) NOT NULL," +
            "owner VARCHAR(10) NULL," +
            "manufacturer VARCHAR(50) NOT NULL," +
            "FOREIGN KEY(owner) REFERENCES Owners(ssn)," +
            "FOREIGN KEY(manufacturer) REFERENCES Manufacturers(brand)) ENGINE = INNODB;");

            ExecuteQueries(commands);
        }

        public void InsertCar(Car car)
        {
            List<string> commands = new List<string>();

            commands.Add("INSERT IGNORE INTO Owners(ssn, birth, name) " +
            "VALUES('" + car.Owner.SSN + "', '" + car.Owner.BirthDate + "', '" + car.Owner.Name + "');");
            commands.Add("INSERT IGNORE INTO Manufacturers(brand) " +
            "VALUES('" + car.Manufacturer.Brand + "');");
            commands.Add("INSERT IGNORE INTO Cars(plate, mileage, year, model, owner, manufacturer) " +
            "VALUES('" + car.Plate + "', " + car.Mileage + ", " + car.Year + ", '" + car.Model + "', '" +
            car.Owner.SSN + "', '" + car.Manufacturer.Brand + "');");

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
    }
}
