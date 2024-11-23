using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    internal class Schedule
    {
        public string VesselName { get; set; }
        public string SourcePort { get; set; }
        public string DestinationPort { get; set; }
        public TimeSpan TravelTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime => DepartureTime + TravelTime;

        public Schedule(string vesselName, string sourcePort, string destinationPort, TimeSpan travelTime, DateTime departureTime)
        {
            VesselName = vesselName;
            SourcePort = sourcePort;
            DestinationPort = destinationPort;
            TravelTime = travelTime;
            DepartureTime = departureTime;
        }

        public static List<Schedule> GenerateSchedules(
            string sourcePort,
            string destinationPort,
            List<string> vesselNames,
            TimeSpan estimatedTravelTime,
            int numberOfSchedules = 3)
        {
            var schedules = new List<Schedule>();
            var random = new Random();

            // Generate schedules for the given number of vessels
            foreach (var vesselName in vesselNames.Take(numberOfSchedules))
            {
                var departureTime = DateTime.Now.AddHours(random.Next(1, 48)); // Random departure in the next 48 hours
                schedules.Add(new Schedule(vesselName, sourcePort, destinationPort, estimatedTravelTime, departureTime));
            }

            return schedules;
        }
    }
}
