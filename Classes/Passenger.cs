using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    public class Passenger
    {
        private static List<string> bookedPassengers = new List<string>();

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

        public bool IsAlreadyBooked()
        {
            string passengerKey = GeneratePassengerKey();
            return bookedPassengers.Contains(passengerKey);
        }

        public void AddToBookedList()
        {
            string passengerKey = GeneratePassengerKey();
            if (!bookedPassengers.Contains(passengerKey))
            {
                bookedPassengers.Add(passengerKey);
            }
        }

        public static void RemoveFromBookedList(string firstName, string middleInitial, string lastName, DateTime dateOfBirth)
        {
            string passengerKey = GeneratePassengerKey(firstName, middleInitial, lastName, dateOfBirth);
            bookedPassengers.Remove(passengerKey);
        }

        public static void RemoveBookedPassenger(string firstName, string middleInitial, string lastName, DateTime dateOfBirth)
        {
            string passengerKey = GeneratePassengerKey(firstName, middleInitial, lastName, dateOfBirth);
            bookedPassengers.Remove(passengerKey);
        }

        private string GeneratePassengerKey()
        {
            return GeneratePassengerKey(FirstName, MiddleInitial, LastName, DateOfBirth);
        }

        private static string GeneratePassengerKey(string firstName, string middleInitial, string lastName, DateTime dateOfBirth)
        {
            return $"{firstName.ToLower()}-{middleInitial.ToLower()}-{lastName.ToLower()}-{dateOfBirth:yyyyMMdd}";
        }

        public static void ClearBookedPassengers()
        {
            bookedPassengers.Clear();
        }
    }
}
