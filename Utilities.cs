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
    }
}
