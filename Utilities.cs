using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferry_Ticketing_App
{
    internal class Utilities
    {
        public static class StringUtils
        {
            /// <summary>
            /// Calculates the Levenshtein Distance between two strings.
            /// </summary>
            /// <param name="source">The first string.</param>
            /// <param name="target">The second string.</param>
            /// <returns>The Levenshtein Distance as an integer.</returns>
            public static int LevenshteinDistance(string source, string target)
            {
                if (string.IsNullOrEmpty(source)) return target.Length;
                if (string.IsNullOrEmpty(target)) return source.Length;

                int[,] dp = new int[source.Length + 1, target.Length + 1];

                for (int i = 0; i <= source.Length; i++) dp[i, 0] = i;
                for (int j = 0; j <= target.Length; j++) dp[0, j] = j;

                for (int i = 1; i <= source.Length; i++)
                {
                    for (int j = 1; j <= target.Length; j++)
                    {
                        int cost = source[i - 1] == target[j - 1] ? 0 : 1;
                        dp[i, j] = Math.Min(
                            Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1),
                            dp[i - 1, j - 1] + cost
                        );
                    }
                }

                return dp[source.Length, target.Length];
            }
        }
        public static class GeoUtils
        {
            // Haversine formula to calculate the distance between two ports
            private static Random rand = new Random();

            public static double GetDistance(double lat1, double lon1, double lat2, double lon2)
            {
                const double R = 6371; // Earth's radius in km

                double lat1Rad = DegreesToRadians(lat1);
                double lon1Rad = DegreesToRadians(lon1);
                double lat2Rad = DegreesToRadians(lat2);
                double lon2Rad = DegreesToRadians(lon2);

                double dLat = lat2Rad - lat1Rad;
                double dLon = lon2Rad - lon1Rad;

                double a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                           Math.Cos(lat1Rad) * Math.Cos(lat2Rad) *
                           Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

                double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

                return R * c; // Distance in kilometers
            }

            public static double DegreesToRadians(double degrees)
            {
                return degrees * (Math.PI / 180);
            }

            public static TimeSpan CalculateTravelTime(double distance, double speedKmPerHour = 30)
            {
                double travelHours = distance / speedKmPerHour;
                return TimeSpan.FromHours(travelHours);
            }

            public static DateTime GetRandomDepartureTime()
            {
                int hour = rand.Next(6, 10); // Random hour between 6 and 9
                int minute = rand.Next(0, 60); // Random minute between 0 and 59
                return new DateTime(2024, 11, 22, hour, minute, 0);
            }
        }
    }
}
