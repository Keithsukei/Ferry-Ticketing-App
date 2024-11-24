using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    internal class Payment
    {
        public int PaymentId { get; set; }
        public int TicketId { get; set; }
        public decimal Price { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public decimal TotalPrice { get; set; }

        public Payment(int paymentId, int ticketId, decimal amount, DateTime paymentDate, string paymentMethod, decimal totalPrice)
        {
            PaymentId = paymentId;
            TicketId = ticketId;
            Price = amount;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
            TotalPrice = totalPrice;
        }
    }
}
