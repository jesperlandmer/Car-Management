using System;

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
    }
}