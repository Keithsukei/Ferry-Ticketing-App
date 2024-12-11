using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    public abstract class Ticket : ITicket
    {
        public int TicketNumber { get; set; }
        public int PassengersID { get; set; }
        public int BookingID { get; set; }
        public int PaymentID { get; set; }
        public int ORNumber { get; set; }
        public string PaymentDetails { get; set; }
        public DateTime BookingDate { get; set; }
        public string FerryName { get; set; }
        public string VesselName { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime IssueDate { get; set; }

        public string TripType { get; set; }
        public string Destination { get; set; }
        public string ContactPerson { get; set; }

        protected Ticket(int ticketNumber, int bookingID, string contactPerson,
            DateTime bookingDate, string tripType, string destination, int orNumber)
        {
            TicketNumber = ticketNumber;
            BookingID = bookingID;
            ContactPerson = contactPerson;
            BookingDate = bookingDate;
            TripType = tripType;
            Destination = destination;
            ORNumber = orNumber;
        }

        public abstract bool Validate();
    }
}
