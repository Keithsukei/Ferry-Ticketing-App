using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    internal class Ports
    {
        public string PortName { get; set; }
        public string Code { get; set; }
        public string City { get; set; }
        public string IslandGroup { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public List<(string Destination, int[] Frequency)> Connections { get; set; }

        public Ports(string portName, string code, string city, string islandGroup, double latitude, double longitude, List<(string, int[])> connections)
        {
            PortName = portName;
            Code = code;
            City = city;
            IslandGroup = islandGroup;
            Latitude = latitude;
            Longitude = longitude;
            Connections = connections;
        }

        public static List<Ports> Port = new List<Ports>
        {
            new Ports("Bacolod Port", "BCD", "Bacolod", "Visayas", 10.6667, 122.95,
                new List<(string, int[])> { ("Iloilo Port", new int[] {1}), ("Manila Port", new int[] {2}), ("Cebu Port", new int[] {1, 2}) }),
            new Ports("Batangas Port", "BAT", "Batangas", "Luzon", 13.7565, 121.0583,
                new List<(string, int[])> { ("Cebu Port", new int[] {1}), ("Dumaguete Port", new int[] {1}), ("Coron Port", new int[] {1}), ("Iloilo Port", new int[] {2}), ("Puerto Princesa Port", new int[] {2}) }),
            new Ports("Boracay Port", "BRC", "Boracay", "Visayas", 11.967, 121.925,
                new List<(string, int[])> { ("Iloilo Port", new int[] {1}), ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("Butuan Port", "BTO", "Butuan", "Mindanao", 8.9475, 125.5406,
                new List<(string, int[])> { ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("Cagayan de Oro Port", "CGY", "Cagayan de Oro", "Mindanao", 8.4811, 124.6458,
                new List<(string, int[])> { ("Ozamis Port", new int[] {1}), ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("Calapan Port", "CLP", "Calapan", "Luzon", 13.4117, 121.1804,
                new List<(string, int[])> { ("Manila Port", new int[] {1}), ("Cebu Port", new int[] {2}) }),
            new Ports("Caticlan Port", "CLI", "Caticlan", "Visayas", 11.9256, 121.956,
                new List<(string, int[])> { ("Romblon Port", new int[] {1}), ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("Cebu Port", "CEB", "Cebu", "Visayas", 10.3167, 123.8963,
                new List<(string, int[])> { ("Tagbilaran Port", new int[] {1}), ("Dumaguete Port", new int[] {1}), ("Surigao Port", new int[] {1}), ("Masbate Port", new int[] {1}), ("Ozamis Port", new int[] {1}),
                ("Coron Port", new int[] {1}), ("Boracay Port", new int[] {1}), ("Malapascua Port", new int[] {1}), ("Manila Port", new int[] {2}), ("Puerto Princesa Port", new int[] {2}) }),
            new Ports("Coron Port", "CRN", "Coron", "Palawan", 12.0022, 120.1985,
                new List<(string, int[])> { ("El Nido Port", new int[] {1}), ("Tagbilaran Port", new int[] {1}), ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("Davao Port", "DVO", "Davao", "Mindanao", 7.1907, 125.4553,
                new List<(string, int[])> { ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("Dinagat Port", "DIN", "Dinagat Islands", "Mindanao", 10.1628, 125.5607,
                new List<(string, int[])> { ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("Dipolog Port", "DPL", "Dipolog", "Mindanao", 8.588, 123.337,
                new List<(string, int[])> { ("Cebu Port", new int[] {1}), ("Manila Port", new int[] {2}) }),
            new Ports("Dumaguete Port", "DGT", "Dumaguete", "Visayas", 9.3075, 123.3026,
                new List<(string, int[])> { ("Tagbilaran Port", new int[] {1}), ("Siquijor Port", new int[] {1}), ("Zamboanga Port", new int[] {1}), ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("El Nido Port", "ELN", "El Nido", "Palawan", 11.2025, 119.4209,
                new List<(string, int[])> { ("Puerto Princesa Port", new int[] {1}), ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("Iloilo Port", "ILO", "Iloilo", "Visayas", 10.6928, 122.5736,
                new List<(string, int[])> { ("Bacolod Port", new int[] {1}), ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("Legazpi Port", "LEG", "Legazpi", "Luzon", 13.1367, 123.7433,
                new List<(string, int[])> { ("Calapan Port", new int[] {1}), ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("Malapascua Port", "MLP", "Malapascua", "Visayas", 11.3391, 124.1249,
                new List<(string, int[])> { ("Cebu Port", new int[] {1}), ("Manila Port", new int[] {2}) }),
            new Ports("Manila Port", "MNL", "Manila", "Luzon", 14.5833, 120.9667,
                new List<(string, int[])> { ("Cebu Port", new int[] {1}), ("Iloilo Port", new int[] {1}), ("Puerto Princesa Port", new int[] {1}), ("Cagayan de Oro Port", new int[] {1}), ("Zamboanga Port", new int[] {1}), ("Davao Port", new int[] {1}), ("Legazpi Port", new int[] {1}), ("Coron Port", new int[] {1}), ("Subic Bay Port", new int[] {1}), ("Dipolog Port", new int[] {1}), ("Tablas Port", new int[] {1}), ("Bacolod Port", new int[] {2}), ("Boracay Port", new int[] {2}), ("Butuan Port", new int[] {2}), ("Calapan Port", new int[] {2}), ("Caticlan Port", new int[] {2}), ("Dinagat Port", new int[] {2}), ("Dumaguete Port", new int[] {2}), ("El Nido Port", new int[] {2}), ("Malapascua Port", new int[] {2}), ("Masbate Port", new int[] {2}), ("Ozamis Port", new int[] {2}), ("Romblon Port", new int[] {2}), ("Roxas Port", new int[] {2}), ("Siargao Port", new int[] {2}), ("Siquijor Port", new int[] {2}), ("Surigao Port", new int[] {2}) }),
            new Ports("Masbate Port", "MLG", "Masbate", "Visayas", 12.3667, 123.6167,
                new List<(string, int[])> { ("Legazpi Port", new int[] {1}), ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("Ozamis Port", "OZC", "Ozamis", "Mindanao", 8.1458, 123.8406,
                new List<(string, int[])> { ("Cebu Port", new int[] {1}), ("Manila Port", new int[] {2}) }),
            new Ports("Puerto Princesa Port", "PPS", "Puerto Princesa", "Palawan", 9.7392, 118.7353,
                new List<(string, int[])> { ("Cebu Port", new int[] {1}), ("El Nido Port", new int[] {1}), ("Manila Port", new int[] {2}), ("Batangas Port", new int[] {2}) }),
            new Ports("Romblon Port", "RBL", "Romblon", "Visayas", 12.5667, 122.275,
                new List<(string, int[])> { ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("Roxas Port", "RXS", "Roxas", "Luzon", 12.5833, 122.75,
                new List<(string, int[])> { ("Caticlan Port", new int[] {1}), ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("Siargao Port", "SGO", "Siargao", "Mindanao", 9.8486, 126.0458,
                new List<(string, int[])> { ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("Siquijor Port", "SIQ", "Siquijor", "Visayas", 9.209, 123.515,
                new List<(string, int[])> { ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("Subic Bay Port", "SBY", "Subic", "Luzon", 14.7956, 120.2926,
                new List<(string, int[])> { ("Manila Port", new int[] {1}), ("Cebu Port", new int[] {2}) }),
            new Ports("Surigao Port", "SUR", "Surigao", "Mindanao", 9.789, 125.4951,
                new List<(string, int[])> { ("Siargao Port", new int[] {1}), ("Cebu Port", new int[] {1}), ("Butuan Port", new int[] {1}), ("Dinagat Port", new int[] {1}), ("Manila Port", new int[] {2}) }),
            new Ports("Tablas Port", "TBS", "Tablas", "Visayas", 12.2675, 122.0595,
                new List<(string, int[])> { ("Roxas Port", new int[] {1}), ("Cebu Port", new int[] {2}), ("Manila Port", new int[] {2}) }),
            new Ports("Tagbilaran Port", "TAG", "Bohol", "Visayas", 9.65, 123.85,
                new List<(string, int[])> { ("Cebu Port", new int[] {1}), ("Puerto Princesa Port", new int[] {1}), ("Siargao Port", new int[] {1}), ("Manila Port", new int[] {2}) }),
            new Ports("Zamboanga Port", "ZAM", "Zamboanga", "Mindanao", 6.9, 122.0667,
                new List<(string, int[])> { ("Cebu Port", new int[] {1}), ("Manila Port", new int[] {2}) })
        };
    }
}
