using System.Text.RegularExpressions;
namespace Easy.Tools.StringHelpers.Extensions
{
    public static class RegexExtensions
    {
        /// <summary>
        /// Returns true if the string matches the given regular expression pattern.
        /// </summary>
        public static bool MatchesRegex(this string input, string pattern) =>
            !string.IsNullOrEmpty(input) && Regex.IsMatch(input, pattern);

        /// <summary>
        /// Extracts all matches for the given regex pattern.
        /// </summary>
        public static List<string> ExtractMatches(this string input, string pattern)
        {
            var matches = Regex.Matches(input, pattern);
            return matches.Cast<Match>().Select(m => m.Value).ToList();
        }
    }
}