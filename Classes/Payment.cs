using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    public class Payment : Price
    {
        public int PaymentId { get; private set; }
        public int TicketId { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public string PaymentMethod { get; private set; }
        public decimal TotalPrice { get; private set; }

        public Payment(int paymentId, int ticketId, decimal basePrice, decimal serviceCharge, 
            DateTime paymentDate, string paymentMethod) 
            : base(basePrice, serviceCharge)
        {
            PaymentId = paymentId;
            TicketId = ticketId;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
            TotalPrice = CalculateFinalPrice();
        }

        public override decimal CalculateFinalPrice()
        {
            return base.CalculateFinalPrice();
        }
    }
}
