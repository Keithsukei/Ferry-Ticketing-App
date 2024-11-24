using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    internal class Accommodation
    {
        public string AccommodationType { get; set; }
        public string SeatType { get; set; }
        public decimal BasePrice { get; set; }

        // Dictionary to hold seat type as key and corresponding Seat object as value
        public static Dictionary<string, Accommodation> AccommodationDictionary { get; set; }

        // Static constructor without access modifier
        static Accommodation()
        {
            AccommodationDictionary = new Dictionary<string, Accommodation>
            {
                {
                    "Reclining Seat",
                    new Accommodation {
                        AccommodationType = "Reclining Seat",
                        SeatType = "Sitting",
                        BasePrice = 100.00m
                    }
                },
                {
                    "Economy Bed Bunk",
                    new Accommodation {
                        AccommodationType = "Economy Bed Bunk",
                        SeatType = "Bed Bunk",
                        BasePrice = 200.00m
                    }
                },
                {
                    "Tourist Bed Bunk",
                    new Accommodation {
                        AccommodationType = "Tourist Bed Bunk",
                        SeatType = "Bed Bunk",
                        BasePrice = 300.00m
                    }
                },
                {
                    "Business Class",
                    new Accommodation {
                        AccommodationType = "Business Class",
                        SeatType = "Premium Sitting",
                        BasePrice = 300.00m
                    }
                }
            };
        }
    }
}
