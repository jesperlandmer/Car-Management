using System;
using System.Collections.Generic;
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
            "name NOT NULL);");

            commands.Add("CREATE TABLE IF NOT EXISTS Manufacturers (" +
            "brand VARCHAR(50) PRIMARY KEY);");

            commands.Add("CREATE TABLE IF NOT EXISTS Cars (" +
            "plate PRIMARY KEY," +
            "mileage NOT NULL," +
            "year NOT NULL," +
            "model NULL," +
            "owner TEXT NULL," +
            "manufacturer NOT NULL," +
            "FOREIGN KEY(owner) REFERENCES users(Owners)," +
            "FOREIGN KEY(brand) REFERENCES subreddits(Brands));");

            ExecuteQueries(commands);
        }

        public void Insert(Car car)
        {
            List<string> commands = new List<string>();

            commands.Add("IF NOT EXISTS (SELECT * FROM Owners WHERE ssn = '" + car.Owner.SSN + "') " + 
            "INSERT INTO Owners(ssn, name) " + 
            "VALUES('" + car.Owner.SSN + "', '" + car.Owner.Name + "')");

            commands.Add("IF NOT EXISTS (SELECT * FROM Manufacturers WHERE brand = '" + car.Manufacturer.Brand + "') " + 
            "INSERT INTO Manufacturers(brand) " + 
            "VALUES('" + car.Manufacturer.Brand + "')");

            commands.Add("IF NOT EXISTS (SELECT * FROM Cars WHERE plate = '" + car.Plate + "') " + 
            "INSERT INTO Cars(plate, mileage, year, model, owner, manufacturer) " + 
            "VALUES('" + car.Plate + "', '" + car.Mileage + "', '" + car.Year + "', '" + car.Model + "', '" + 
            car.Owner + "', '" + car.Manufacturer + "')");

            ExecuteQueries(commands);
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
