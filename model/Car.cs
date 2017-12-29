using System;

namespace CarManagement.model
{
    public class Car
    {
        public string Plate { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public string Model { get; set; }
        public Owner Owner { get; set; }
        public int Mileage { get; set; }
        public int Year { get; set; }

        public Car(string plate, Manufacturer manufacturer, string model, Owner owner, int mileage, int year)
        {
            Plate = plate;
            Manufacturer = manufacturer;
            Model = model;
            Owner = owner;
            Mileage = mileage;
            Year = year;
        }
    }
}