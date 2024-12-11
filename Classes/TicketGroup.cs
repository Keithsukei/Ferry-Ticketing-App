using Ferry_Ticketing_App.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    public class TicketGroup
    {
        public ucTicket DepartureTicket { get; set; }
        public ucTicket ReturnTicket { get; set; }
    }
}
