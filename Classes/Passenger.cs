using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    internal class Passenger
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Type { get; set; }
        public string Nationality { get; set; }

        public Passenger(int id, string firstName, string middleInitial, string lastName, string gender, DateTime dateOfBirth, string type, string nationality)
        {
            Id = id;
            FirstName = firstName;
            MiddleInitial = middleInitial;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Type = type;
            Nationality = nationality;
        }
    }
}
