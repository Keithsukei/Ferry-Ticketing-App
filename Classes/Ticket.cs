using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    internal class Ticket
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

        public Ticket(int ticketNumber, int passengersID, int bookingID, int paymentID, int orNumber, string paymentDetails, DateTime bookingDate, string ferryName, string vesselName, decimal totalPrice, DateTime issueDate)
        {
            TicketNumber = ticketNumber;
            PassengersID = passengersID;
            BookingID = bookingID;
            PaymentID = paymentID;
            ORNumber = orNumber;
            PaymentDetails = paymentDetails;
            BookingDate = bookingDate;
            FerryName = ferryName;
            VesselName = vesselName;
            TotalPrice = totalPrice;
            IssueDate = issueDate;
        }
    }
}
