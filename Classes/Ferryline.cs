using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    internal class Ferryline
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string VesselName { get; set; }

        public Ferryline(int id, string company, string vesselName)
        {
            Id = id;
            Company = company;
            VesselName = vesselName;
        }

        public static List<Ferryline> AllTrips { get; } = new List<Ferryline>
        {
            new Ferryline(1, "Aerian Ferries Co.", "MV Queen of the Seas"),
            new Ferryline(2, "Aerian Ferries Co.", "MV Island Voyager"),
            new Ferryline(3, "Aerian Ferries Co.", "MV Ocean Sprinter"),
            new Ferryline(4, "Aerian Ferries Co.", "MV Paradise Cruiser"),
            new Ferryline(5, "Aerian Ferries Co.", "MV Coastal Navigator"),
            new Ferryline(6, "Aerian Ferries Co.", "MV Island Express"),
            new Ferryline(7, "Aerian Ferries Co.", "MV Ocean Explorer"),
            new Ferryline(8, "Aerian Ferries Co.", "MV Wave Rider"),
            new Ferryline(9, "Aerian Ferries Co.", "MV Horizon Seeker"),
            new Ferryline(10, "Aerian Ferries Co.", "MV Sea Pathfinder"),
            new Ferryline(11, "Aerian Ferries Co.", "MV Archipelago Adventurer"),
            new Ferryline(12, "Aerian Ferries Co.", "MV Pacific Spirit"),
            new Ferryline(13, "Aerian Ferries Co.", "MV Ocean Odyssey"),
            new Ferryline(14, "Aerian Ferries Co.", "MV Island Hopper"),
            new Ferryline(15, "Aerian Ferries Co.", "MV Coral Voyager"),
        };
    }
}
