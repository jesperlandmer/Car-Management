using System;

namespace CarManagement.view
{
    public class CarView
    {

        public string GetLicencePlate()
        {
            System.Console.WriteLine("Enter Licence Plate (AAA000):");
            return Console.ReadLine();
        }
        public model.Model GetModel()
        {
            System.Console.WriteLine("Enter Manufacturer:");
            int counter = 1;

            foreach (model.Manufacturer b in Enum.GetValues(typeof(model.Manufacturer)))
            {
                System.Console.WriteLine(counter + ". " + b.ToString());
                counter++;
            }

            ConsoleKeyInfo keyinfo = Console.ReadKey(true);
            return new model.Model(GetModelName(), (model.Manufacturer)Convert.ToInt32(keyinfo.KeyChar.ToString()));
        }
        public string GetModelName()
        {
            System.Console.WriteLine("Enter Model:");
            return Console.ReadLine();
        }
        public model.Owner GetOwner()
        {
            return new model.Owner(GetOwnerSSN(), GetOwnerName());
        }
        public string GetOwnerSSN()
        {
            System.Console.WriteLine("Enter Owner SSN (yymmddxxxx):");
            return Console.ReadLine();
        }
        public string GetOwnerName()
        {
            System.Console.WriteLine("Enter Owner Name:");
            return Console.ReadLine();
        }

        public int GetMileage()
        {
            System.Console.WriteLine("Enter Mileage:");
            return Convert.ToInt32(Console.ReadLine());
        }
        public int GetYear()
        {
            System.Console.WriteLine("Enter Production Year:");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}