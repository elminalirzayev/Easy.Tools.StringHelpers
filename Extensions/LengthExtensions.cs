namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods for checking string lengths.
    /// </summary>
    public static class LengthExtensions
    {
        /// <summary>
        /// Returns true if the string length is greater than the specified value.
        /// </summary>
        /// <param name="input">The input string to check.</param>
        /// <param name="length">The length to compare against.</param>
        /// <returns>True if the string is longer than the specified length; otherwise, false.</returns>
        public static bool LongerThan(this string input, int length) =>
            !string.IsNullOrEmpty(input) && input.Length > length;

        /// <summary>
        /// Returns true if the string length is less than the specified value.
        /// </summary>
        ///  <param name="input">The input string to check.</param>
        ///  <param name="length">The length to compare against.</param>
        ///  <returns>True if the string is shorter than the specified length; otherwise, false.</returns>
        public static bool ShorterThan(this string input, int length) =>
            string.IsNullOrEmpty(input) || input.Length < length;
    }
}
