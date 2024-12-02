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

        public interface ITicketDataManager
        {
            void AddTicketData(string transactionNo, string orNo, string contactPerson, string departureDate, string eta, string dateBooked);
            List<TicketData> GetTicketData();
        }

        public class TicketData : ITicketDataManager
        {
            private string _transactionNo;
            private string _orNo;
            private string _contactPerson;
            private string _departureDate;
            private string _eta;
            private string _dateBooked;

            public string TransactionNo { get { return _transactionNo; } set { _transactionNo = value; } }
            public string ORNo { get { return _orNo; } set { _orNo = value; } }
            public string ContactPerson { get { return _contactPerson; } set { _contactPerson = value; } }
            public string DepartureDate { get { return _departureDate; } set { _departureDate = value; } }
            public string ETA { get { return _eta; } set { _eta = value; } }
            public string DateBooked { get { return _dateBooked; } set { _dateBooked = value; } }

            public void AddTicketData(string transactionNo, string orNo, string contactPerson, string departureDate, string eta, string dateBooked)
            {
                // Implement the logic to add a new ticket data
                _transactionNo = transactionNo;
                _orNo = orNo;
                _contactPerson = contactPerson;
                _departureDate = departureDate;
                _eta = eta;
                _dateBooked = dateBooked;
            }

            public List<TicketData> GetTicketData()
            {
                // Implement the logic to retrieve the ticket data
                return new List<TicketData> { this };
            }
        }
    }
}
