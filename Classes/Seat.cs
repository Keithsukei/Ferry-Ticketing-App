using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    internal class Seat
    {
        public string SeatType { get; set; }

        // Dictionary to hold seat type as key and corresponding Seat object as value
        public static Dictionary<string, Seat> SeatDictionary { get; set; }

        // Static constructor without access modifier
        static Seat()
        {
            SeatDictionary = new Dictionary<string, Seat>
                {
                    { "Reclining Seat", new Seat { SeatType = "Reclining Seat" } },
                    { "Economy Bed Bunk", new Seat { SeatType = "Economy Bed Bunk" } },
                    { "Tourist Bed Bunk", new Seat { SeatType = "Tourist Bed Bunk" } },
                    { "Business Class", new Seat { SeatType = "Business Class" } }
                };
        }
    }
}
