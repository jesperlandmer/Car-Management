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
            attributes = new List<string>();
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
        public void GetMostPopularBrand()
        {

        }
        public void GetMilesPerDecade()
        {

        }
        public void GetMilesPerBrand()
        {

        }
        public void GetMilesPerYear()
        {

        }
    }
}