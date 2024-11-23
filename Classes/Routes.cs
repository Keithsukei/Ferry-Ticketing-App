using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    internal class Routes
    {
        private List<(string sourcePort, string destinationPort, string[] ferryLines)> routes;
        private List<Ports> allPorts;
        public Routes(List<Ports> portsFromPortsClass)
        {
            this.allPorts = portsFromPortsClass;
            this.routes = new List<(string, string, string[])>
            {
                ("Bacolod Port", "Iloilo Port", new string[] { "Aerian Ferries Co." }),
                ("Batangas Port", "Cebu Port", new string[] { "Aerian Ferries Co." }),
                ("Batangas Port", "Dumaguete Port", new string[] { "Aerian Ferries Co." }),
                ("Batangas Port", "Coron Port", new string[] { "Aerian Ferries Co." }),
                ("Boracay Port", "Cebu Port", new string[] { "Aerian Ferries Co." }),
                ("Boracay Port", "Iloilo Port", new string[] { "Aerian Ferries Co." }),
                ("Butuan Port", "Surigao Port", new string[] { "Aerian Ferries Co." }),
                ("Cagayan de Oro Port", "Manila Port", new string[] { "Aerian Ferries Co." }),
                ("Cagayan de Oro Port", "Ozamis Port", new string[] { "Aerian Ferries Co." }),
                ("Calapan Port", "Legazpi Port", new string[] { "Aerian Ferries Co." }),
                ("Caticlan Port", "Roxas Port", new string[] { "Aerian Ferries Co." }),
                ("Caticlan Port", "Romblon Port", new string[] { "Aerian Ferries Co." }),
                ("Cebu Port", "Manila Port", new string[] { "Aerian Ferries Co." }),
                ("Cebu Port", "Tagbilaran Port", new string[] { "Aerian Ferries Co." }),
                ("Cebu Port", "Dumaguete Port", new string[] { "Aerian Ferries Co." }),
                ("Cebu Port", "Puerto Princesa Port", new string[] { "Aerian Ferries Co." }),
                ("Cebu Port", "Surigao Port", new string[] { "Aerian Ferries Co." }),
                ("Cebu Port", "Masbate Port", new string[] { "Aerian Ferries Co." }),
                ("Cebu Port", "Ozamis Port", new string[] { "Aerian Ferries Co." }),
                ("Cebu Port", "Zamboanga Port", new string[] { "Aerian Ferries Co." }),
                ("Cebu Port", "Coron Port", new string[] { "Aerian Ferries Co." }),
                ("Cebu Port", "Dipolog Port", new string[] { "Aerian Ferries Co." }),
                ("Cebu Port", "Malapascua Port", new string[] { "Aerian Ferries Co." }),
                ("Coron Port", "Manila Port", new string[] { "Aerian Ferries Co." }),
                ("Coron Port", "El Nido Port", new string[] { "Aerian Ferries Co." }),
                ("Coron Port", "Tagbilaran Port", new string[] { "Aerian Ferries Co." }),
                ("Davao Port", "Manila Port", new string[] { "Aerian Ferries Co." }),
                ("Dinagat Port", "Surigao Port", new string[] { "Aerian Ferries Co." }),
                ("Dipolog Port", "Manila Port", new string[] { "Aerian Ferries Co." }),
                ("Dumaguete Port", "Tagbilaran Port", new string[] { "Aerian Ferries Co." }),
                ("Dumaguete Port", "Siquijor Port", new string[] { "Aerian Ferries Co." }),
                ("Dumaguete Port", "Zamboanga Port", new string[] { "Aerian Ferries Co." }),
                ("El Nido Port", "Puerto Princesa Port", new string[] { "Aerian Ferries Co." }),
                ("Iloilo Port", "Manila Port", new string[] { "Aerian Ferries Co." }),
                ("Legazpi Port", "Manila Port", new string[] { "Aerian Ferries Co." }),
                ("Legazpi Port", "Masbate Port", new string[] { "Aerian Ferries Co." }),
                ("Manila Port", "Puerto Princesa Port", new string[] { "Aerian Ferries Co." }),
                ("Manila Port", "Zamboanga Port", new string[] { "Aerian Ferries Co." }),
                ("Manila Port", "Subic Bay Port", new string[] { "Aerian Ferries Co." }),
                ("Manila Port", "Tablas Port", new string[] { "Aerian Ferries Co." }),
                ("Puerto Princesa Port", "Tagbilaran Port", new string[] { "Aerian Ferries Co." }),
                ("Roxas Port", "Tablas Port", new string[] { "Aerian Ferries Co." }),
                ("Siargao Port", "Surigao Port", new string[] { "Aerian Ferries Co." }),
                ("Siargao Port", "Tagbilaran Port", new string[] { "Aerian Ferries Co." }),

            };
        }
    }
}
