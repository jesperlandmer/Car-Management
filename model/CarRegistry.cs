using System;
using System.Collections.Generic;

namespace CarManagement.model
{
    public class CarRegistry
    {
        private DBHelper m_db;
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

        public string GetOldestAndYoungestOwners()
        {
            string command = "SELECT * FROM Cars WHERE owner = " + 
            "(SELECT ssn FROM Owners WHERE birth = (SELECT MIN(birth) FROM Owners));";
            return m_db.ReadDB(command);
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