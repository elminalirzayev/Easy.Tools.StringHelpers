namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods for parsing dates from strings.
    /// </summary>
    public static class DateParsingExtensions
    {
        /// <summary>
        /// Checks if the string contains a valid date.
        /// </summary>
        /// <param name="input">The input string to check.</param>
        /// <returns>True if the string can be parsed as a date; otherwise, false.</returns>
        public static bool ContainsDate(this string input) =>
            DateTime.TryParse(input, out _);
    }
}
