using System;

namespace CarManagement.model
{
    public class Owner
    {
        public string SSN { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public Owner(string ssn, string name)
        {
            SSN = ssn;
            BirthDate = GetDatetime(ssn);
            Name = name;
        }
        private DateTime GetDatetime(string ssn)
        {
            string year = ssn.Substring(0, 2);
            string month = ssn.Substring(2, 2);
            string day = ssn.Substring(4, 2);

            string date = year + "/" + month + "/" + day;
            return Convert.ToDateTime(date);
        }
    }
}