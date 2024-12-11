using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    public interface ITicket
    {
        int TicketNumber { get; set; }
        int PassengersID { get; set; }
        int BookingID { get; set; }
        int PaymentID { get; set; }
        int ORNumber { get; set; }
        string PaymentDetails { get; set; }
        DateTime BookingDate { get; set; }
        string FerryName { get; set; }
        string VesselName { get; set; }
        decimal TotalPrice { get; set; }
        DateTime IssueDate { get; set; }
    }
}
