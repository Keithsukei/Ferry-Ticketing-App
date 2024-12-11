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

        public static Dictionary<string, Accommodation> AccommodationDictionary { get; set; }

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
                    "Economy",
                    new Accommodation {
                        AccommodationType = "Economy",
                        SeatType = "Bed Bunk",
                        BasePrice = 200.00m
                    }
                },
                {
                    "Tourist",
                    new Accommodation {
                        AccommodationType = "Tourist",
                        SeatType = "Bed Bunk",
                        BasePrice = 300.00m
                    }
                },
                {
                    "Business Class",
                    new Accommodation {
                        AccommodationType = "Business Class",
                        SeatType = "Premium Sitting",
                        BasePrice = 500.00m
                    }
                }
            };
        }
    }
}
