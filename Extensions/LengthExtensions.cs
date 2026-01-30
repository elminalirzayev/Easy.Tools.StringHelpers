using System;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods for checking string lengths safely.
    /// </summary>
    public static class LengthExtensions
    {
        /// <summary>
        /// Checks if the string length is greater than the specified value.
        /// Returns false if the input is null.
        /// </summary>
        /// <param name="input">The input string to check.</param>
        /// <param name="length">The length to compare against.</param>
        /// <returns>True if the string is longer than the specified length; otherwise, false.</returns>
        public static bool LongerThan(this string input, int length)
        {
            return !string.IsNullOrEmpty(input) && input.Length > length;
        }

        /// <summary>
        /// Checks if the string length is less than the specified value.
        /// Returns true if the input is null or empty (treating them as length 0).
        /// </summary>
        /// <param name="input">The input string to check.</param>
        /// <param name="length">The length to compare against.</param>
        /// <returns>True if the string is shorter than the specified length; otherwise, false.</returns>
        public static bool ShorterThan(this string input, int length)
        {
            // Treat null as empty (length 0) for safe comparison
            if (string.IsNullOrEmpty(input)) return 0 < length;
            return input.Length < length;
        }

        /// <summary>
        /// Checks if the string length is exactly equal to the specified value.
        /// Returns true if input is null/empty and length is 0.
        /// </summary>
        /// <param name="input">The input string to check.</param>
        /// <param name="length">The exact length required.</param>
        /// <returns>True if the string length matches; otherwise, false.</returns>
        public static bool IsLengthEqual(this string input, int length)
        {
            if (string.IsNullOrEmpty(input)) return length == 0;
            return input.Length == length;
        }

        /// <summary>
        /// Checks if the string length is between a minimum and maximum value (inclusive).
        /// </summary>
        /// <param name="input">The input string to check.</param>
        /// <param name="min">Minimum length.</param>
        /// <param name="max">Maximum length.</param>
        /// <returns>True if the length is within range; otherwise, false.</returns>
        public static bool IsLengthBetween(this string input, int min, int max)
        {
            int len = string.IsNullOrEmpty(input) ? 0 : input.Length;
            return len >= min && len <= max;
        }
    }
}