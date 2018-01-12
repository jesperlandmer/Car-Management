using System;
using System.Collections.Generic;

namespace CarManagement.view
{
    public enum MenuOption
    {
        AddCar = 1,
        RemoveCar = 2,
        Statistics = 3,
        Quit = 4
    }
    public enum StatsOption
    {
        OldYoung = 1,
        PopularBrand = 2,
        AvgDecade = 3,
        AvgBrand = 4,
        AvgMile = 5,
        Quit = 6
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
            Console.Clear();
            System.Console.WriteLine("\tCar Management Beta 1.0");
            System.Console.WriteLine("===========================================");

            System.Console.WriteLine("1. Add new Car");
            System.Console.WriteLine("2. Remove Car");
            System.Console.WriteLine("3. Statistics");
            System.Console.WriteLine("4. Quit");
        }

        public MenuOption GetMenuOption()
        {
            ConsoleKeyInfo keyinfo = Console.ReadKey(true);
            return (MenuOption)Int32.Parse(keyinfo.KeyChar.ToString());
        }
        public void DisplayStatsMenu()
        {
            Console.Clear();
            System.Console.WriteLine("\tCar Management Beta 1.0");
            System.Console.WriteLine("===========================================");

            System.Console.WriteLine("1. Oldest And Youngest Driver");
            System.Console.WriteLine("2. Most Popular Manufacturer");
            System.Console.WriteLine("3. Average Mileage Per Decade");
            System.Console.WriteLine("4. Average Mileage Per Manufacturer");
            System.Console.WriteLine("5. Average Mileage Per Production Year");
            System.Console.WriteLine("6. Quit");
        }
        public void DisplayResult(List<KeyValuePair<string, string>> kvpList)
        {
            int count = 0;
            string str = "";
            foreach (var kvp in kvpList)
            {
                if (count == 0)
                {
                    str = kvp.Key;
                    count++;
                }

                if (kvp.Key == str)
                {
                    Console.WriteLine("----------------------------");
                }

                Console.WriteLine(string.Format("{0}: {1}", kvp.Key, kvp.Value));
            }
        }
        public StatsOption GetStatsOption()
        {
            ConsoleKeyInfo keyinfo = Console.ReadKey(true);
            return (StatsOption)Int32.Parse(keyinfo.KeyChar.ToString());
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
        public model.Car DoRemoveCar()
        {
            return new model.Car(v_car.GetLicencePlate());
        }
    }
}