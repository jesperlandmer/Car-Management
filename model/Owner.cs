using System;

namespace CarManagement.model
{
    public class Owner
    {
        public string SSN { get; set; }
        public string Name { get; set; }
        public Owner(string ssn, string name)
        {
            SSN = ssn;
            Name = name;
        }
    }
}