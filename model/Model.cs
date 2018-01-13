using System;

namespace CarManagement.model
{
    public enum Manufacturer
    {
        BMW,
        Mercedes,
        Volvo,
        Volkswagen,
        Toyota,
        Others
    }
    public class Model
    {
        public string ModelName { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Model(string modelName, Manufacturer manufacturer)
        {
            ModelName = modelName;
            Manufacturer = manufacturer;
        }
    }
}