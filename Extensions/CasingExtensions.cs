using System.Globalization;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods related to string casing transformations.
    /// </summary>
    public static class CasingExtensions
    {
        /// <summary>
        /// Converts the string to title case (e.g., "hello world" -> "Hello World").
        /// Note: This method converts the rest of the string to lowercase first to ensure proper casing.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <param name="culture">Optional. The culture to use. Defaults to CurrentCulture.</param>
        /// <returns>The title-cased string, or empty string if input is null.</returns>
        public static string ToTitleCase(this string input, CultureInfo? culture = null)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            var ci = culture ?? CultureInfo.CurrentCulture;
            // TextInfo.ToTitleCase does not lower-case all-caps words unless forced.
            return ci.TextInfo.ToTitleCase(input.ToLower(ci));
        }

        /// <summary>
        /// Converts the string to lowercase using invariant culture.
        /// Safe for null inputs.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>Lowercase string or empty.</returns>
        public static string ToInvariantLower(this string input) =>
            input?.ToLowerInvariant() ?? string.Empty;

        /// <summary>
        /// Converts the string to uppercase using invariant culture.
        /// Safe for null inputs.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>Uppercase string or empty.</returns>
        public static string ToInvariantUpper(this string input) =>
            input?.ToUpperInvariant() ?? string.Empty;
    }
}