using System;
using System.Collections.Generic;

namespace CarManagement.model
{
    public class CarRegistry
    {
        private DBHelper m_db;
        private List<string> attributes;
        public CarRegistry()
        {
            m_db = new DBHelper();
        }
        public void LoadDatabase()
        {
            m_db.CreateTables();
        }
        public void AddCar(Car m_car)
        {
            m_db.InsertCar(m_car);
        }
        public void RemoveCar(Car m_car)
        {
            m_db.RemoveCar(m_car);
        }

        public List<KeyValuePair<string, string>> GetOldestAndYoungestOwners()
        {
            attributes = new List<string>();
            attributes.Add("name");
            attributes.Add("birth");
            attributes.Add("mileage");

            string command = "SELECT Owners.name, Owners.birth, Cars.plate, Cars.mileage " +
            "FROM Owners JOIN Cars ON Cars.owner = Owners.ssn WHERE Owners.birth = " +
            "(SELECT MAX(birth) FROM Owners) " +
            "UNION SELECT Owners.name, Owners.birth, Cars.plate, Cars.mileage " +
            "FROM Owners JOIN Cars ON Cars.owner = Owners.ssn WHERE Owners.birth = " +
            "(SELECT MIN(birth) FROM Owners);";

            return m_db.ReadDB(command, attributes);
        }
        public List<KeyValuePair<string, string>> GetMostPopularBrand()
        {
            attributes = new List<string>();
            attributes.Add("manufacturer");
            attributes.Add("frequency");

            string command = "SELECT manufacturer, COUNT(manufacturer) " +
            "AS frequency FROM Cars c INNER JOIN Models m ON c.model = m.model " +
            "GROUP BY manufacturer ORDER BY COUNT(manufacturer) DESC LIMIT 1;";

            return m_db.ReadDB(command, attributes);
        }
        public List<KeyValuePair<string, string>> GetMilesPerDecade()
        {
            attributes = new List<string>();
            attributes.Add("decade");
            attributes.Add("avg_mileage");

            string command = "SELECT FLOOR(YEAR(o.birth) / 10 ) * 10 AS decade, " +
            "(SUM(mileage) / COUNT(ssn)) AS avg_mileage FROM Owners o INNER JOIN Cars c " +
            "ON o.ssn = c.owner GROUP BY decade ORDER BY decade DESC;";

            return m_db.ReadDB(command, attributes);
        }
        public List<KeyValuePair<string, string>> GetMilesPerBrand()
        {
            attributes = new List<string>();
            attributes.Add("manufacturer");
            attributes.Add("avg_mileage");

            string command = "SELECT manufacturer, avg(mileage) AS avg_mileage " +
            "FROM Cars c INNER JOIN Models m ON c.model = m.model GROUP BY manufacturer " +
            "ORDER BY avg_mileage DESC;";

            return m_db.ReadDB(command, attributes);
        }
        public List<KeyValuePair<string, string>> GetMilesPerYear()
        {
            attributes = new List<string>();
            attributes.Add("year");
            attributes.Add("avg_mileage");

            string command = "SELECT year, avg(mileage) AS avg_mileage" + 
            " FROM Cars GROUP BY year ORDER BY avg_mileage DESC;";

            return m_db.ReadDB(command, attributes);
        }
    }
}