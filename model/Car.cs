using System;

namespace CarManagement.model
{
    public class Car
    {
        public string Plate { get; set; }
        public Model Model { get; set; }
        public Owner Owner { get; set; }
        public int Mileage { get; set; }
        public int Year { get; set; }

        public Car(string plate)
        {
            Plate = plate;
        }
        public Car(string plate, Model model, Owner owner, int mileage, int year)
        {
            Plate = plate;
            Model = model;
            Owner = owner;
            Mileage = mileage;
            Year = year;
        }
    }
}