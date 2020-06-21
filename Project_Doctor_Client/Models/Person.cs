using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Doctor_Client.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfArrival { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Address { get; set; }
        public string Symptom { get; set; }
        public string Diagnosis { get; set; }
        public DateTime LastTimeEdited { get; set; }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} | SSN: {SocialSecurityNumber} | Last time edited: {LastTimeEdited}";
        }
    }
}
