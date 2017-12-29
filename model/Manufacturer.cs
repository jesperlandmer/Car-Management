using System;

namespace CarManagement.model
{
    public enum Brand
    {
        BMW,
        Mercedes,
        Volvo,
        Volkswagen,
        Toyota,
        Others
    }
    public class Manufacturer
    {
        public Brand Brand { get; set; }
        public Manufacturer(Brand brand)
        {
            Brand = brand;
        }
    }
}