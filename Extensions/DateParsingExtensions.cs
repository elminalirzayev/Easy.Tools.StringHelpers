using System;
using System.Globalization;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods for parsing dates from strings.
    /// </summary>
    public static class DateParsingExtensions
    {
        /// <summary>
        /// Checks if the string represents a valid date.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>True if valid date.</returns>
        public static bool IsValidDate(this string input) => DateTime.TryParse(input, out _);

        /// <summary>
        /// Checks if the string represents a valid date with explicit format.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="format">Date format (e.g. "yyyy-MM-dd").</param>
        /// <param name="provider">Format provider (default Invariant).</param>
        /// <returns>True if valid.</returns>
        public static bool IsValidDateExact(this string input, string format, IFormatProvider? provider = null) =>
             DateTime.TryParseExact(input, format, provider ?? CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
    }
}