using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App.Classes
{
    internal class Time
    {
        private static readonly Random _random = new Random();

        public Ferryline FerryLine { get; set; }
        public string SourcePort { get; set; }
        public string DestinationPort { get; set; }
        public TimeSpan TravelTime { get; set; }
        public DateTime DepartureTime { get; set; }

        public Time(Ferryline ferryLine, string sourcePort, string destinationPort, TimeSpan travelTime, DateTime departureTime)
        {
            FerryLine = ferryLine;
            SourcePort = sourcePort;
            DestinationPort = destinationPort;
            TravelTime = travelTime;
            DepartureTime = departureTime;
        }

        public static List<Time> GenerateSchedules(string sourcePort, string destinationPort,
            List<Ferryline> ferrylines, List<Ports> ports, int numberOfSchedules = 3)
        {
            var schedules = new List<Time>();

            // Validate input parameters
            if (string.IsNullOrEmpty(sourcePort) || string.IsNullOrEmpty(destinationPort) ||
                ferrylines == null || !ferrylines.Any() || ports == null || !ports.Any())
            {
                return schedules;
            }

            // Get port coordinates
            var sourcePortData = ports.FirstOrDefault(p => p.PortName == sourcePort);
            var destPortData = ports.FirstOrDefault(p => p.PortName == destinationPort);

            if (sourcePortData == null || destPortData == null)
                return schedules;

            // Calculate distance between ports
            double distance = Utilities.GeoUtils.GetDistance(
                sourcePortData.Latitude, sourcePortData.Longitude,
                destPortData.Latitude, destPortData.Longitude
            );

            // Get available ferry lines for this route
            var availableFerryLines = GetAvailableFerryLines(sourcePort, destinationPort, ferrylines, ports);

            // Check if we have any available ferry lines
            if (!availableFerryLines.Any())
            {
                return schedules;
            }

            // Adjust numberOfSchedules if we have fewer available ferries
            numberOfSchedules = Math.Min(numberOfSchedules, availableFerryLines.Count);

            for (int i = 0; i < numberOfSchedules; i++)
            {
                // Get random ferry from available ferries
                var randomFerry = availableFerryLines[_random.Next(availableFerryLines.Count)];

                // Generate random speed between 25-35 knots
                double speedKmh = _random.Next(25, 36);

                // Calculate travel time based on distance and speed
                TimeSpan travelTime = Utilities.GeoUtils.CalculateTravelTime(distance, speedKmh);

                // Get random departure time
                DateTime departureTime = Utilities.GeoUtils.GetRandomDepartureTime();

                // Create new schedule
                var schedule = new Time(
                    randomFerry,
                    sourcePort,
                    destinationPort,
                    travelTime,
                    departureTime
                );

                schedules.Add(schedule);
            }

            // Sort schedules by departure time
            return schedules.OrderBy(s => s.DepartureTime).ToList();
        }

        private static List<Ferryline> GetAvailableFerryLines(string sourcePort, string destinationPort,
            List<Ferryline> ferrylines, List<Ports> ports)
        {
            if (string.IsNullOrEmpty(sourcePort) || string.IsNullOrEmpty(destinationPort) ||
                ferrylines == null || !ferrylines.Any() || ports == null || !ports.Any())
            {
                return new List<Ferryline>();
            }

            // Get frequency data from port connections
            var sourcePortData = ports.FirstOrDefault(p => p.PortName == sourcePort);

            if (sourcePortData?.Connections == null)
            {
                return new List<Ferryline>();
            }

            var connection = sourcePortData.Connections.FirstOrDefault(c => c.Destination == destinationPort);

            // Check if connection exists and has valid frequency data
            if (connection.Frequency == null || connection.Frequency.Length == 0)
            {
                return new List<Ferryline>();
            }

            // Get ferries based on frequency values (1 or 2)
            var availableFerryLines = new List<Ferryline>();
            foreach (var freq in connection.Frequency)
            {
                int maxFerryId = freq == 1 ? 7 : 15;
                var eligibleFerries = ferrylines.Where(f => f.Id <= maxFerryId).ToList();

                if (eligibleFerries.Any())
                {
                    var ferries = eligibleFerries
                        .OrderBy(x => _random.Next())
                        .Take(freq == 1 ? Math.Min(2, eligibleFerries.Count) : Math.Min(3, eligibleFerries.Count));

                    availableFerryLines.AddRange(ferries);
                }
            }

            return availableFerryLines.Distinct().ToList();
        }

        public override string ToString()
        {
            return $"{SourcePort} to {DestinationPort} ({FerryLine.Company} - {FerryLine.VesselName}) | " +
                   $"Departure: {DepartureTime:HH:mm} | Travel Time: {TravelTime:hh\\:mm} | Arrival: {DepartureTime.Add(TravelTime):HH:mm}";
        }
    }
}
