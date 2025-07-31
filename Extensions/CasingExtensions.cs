using System.Globalization;
namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods related to string casing transformations.
    /// </summary>
    public static class CasingExtensions
    {
        /// <summary>
        /// Converts the string to title case (e.g., "hello world" → "Hello World").
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <param name="culture">Optional. The culture to use for the conversion. Defaults to the current culture.</param>
        /// <returns>The title-cased string.</returns>
        public static string ToTitleCase(this string input, CultureInfo? culture = null)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            var ci = culture ?? CultureInfo.CurrentCulture;
            return ci.TextInfo.ToTitleCase(input.ToLower());
        }

        /// <summary>
        /// Converts the string to lowercase using invariant culture.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The lowercase string.</returns>

        public static string ToInvariantLower(this string input) =>
            input?.ToLowerInvariant() ?? string.Empty;

        /// <summary>
        /// Converts the string to uppercase using invariant culture.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The uppercase string.</returns>
        public static string ToInvariantUpper(this string input) =>
            input?.ToUpperInvariant() ?? string.Empty;
    }

}