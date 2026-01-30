using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods for regex operations.
    /// </summary>
    public static class RegexExtensions
    {
        // Default timeout to prevent ReDoS (Regular Expression Denial of Service)
        private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(2);

        /// <summary>
        /// Returns true if the string matches the given regular expression pattern.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="pattern">The regex pattern.</param>
        /// <param name="options">Regex options (default: None).</param>
        /// <returns>True if match found.</returns>
        public static bool MatchesRegex(this string input, string pattern, RegexOptions options = RegexOptions.None)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern)) return false;
            try
            {
                return Regex.IsMatch(input, pattern, options, DefaultTimeout);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Extracts all matches for the given regex pattern as a list of strings.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="pattern">The regex pattern.</param>
        /// <returns>List of matched strings.</returns>
        public static List<string> ExtractMatches(this string input, string pattern)
        {
            if (string.IsNullOrEmpty(input) || string.IsNullOrEmpty(pattern)) return new List<string>();

            try
            {
                var matches = Regex.Matches(input, pattern, RegexOptions.None, DefaultTimeout);
                return matches.Cast<Match>().Select(m => m.Value).ToList();
            }
            catch (RegexMatchTimeoutException)
            {
                return new List<string>();
            }
        }
    }
}