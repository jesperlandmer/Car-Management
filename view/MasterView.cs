using System;

namespace CarManagement.view
{
    public enum MenuOption
    {
        AddCar = 1,
        RemoveCar = 2,
        Statistics = 3,
        Quit = 4
    }
    public class MasterView
    {
        private CarView v_car;
        public MasterView()
        {
            v_car = new CarView();
        }
        public void DisplayMenu()
        {
            System.Console.WriteLine("\tCar Management Beta 1.0");
            System.Console.WriteLine("===========================================");

            System.Console.WriteLine("1. Add new Car");
            System.Console.WriteLine("2. Remove Car");
            System.Console.WriteLine("3. Statistics");
            System.Console.WriteLine("4. Quit");
        }
        public model.Car DoCar()
        {
            return new model.Car(
                v_car.GetLicencePlate(), 
                v_car.GetManufacturer(),
                v_car.GetModel(), 
                v_car.GetOwner(), 
                v_car.GetMileage(), 
                v_car.GetYear());
        }
    }
}