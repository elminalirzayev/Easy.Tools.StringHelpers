using System.Text.RegularExpressions;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods related to string manipulation.
    /// </summary>
    public static class ManipulationExtensions
    {
        /// <summary>
        /// Removes all whitespace characters from the string.
        /// </summary>
        /// <param name="input">The input string to process.</param>
        ///  <returns>The string with all whitespace removed.</returns>
        ///  This method uses a regular expression to match one or more whitespace characters
        ///  and replaces them with an empty string.
        public static string RemoveWhitespace(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return Regex.Replace(input, @"\s+", "");
        }

        /// <summary>
        /// Repeats the string a specified number of times.
        /// </summary>
        ///  <param name="input">The input string to repeat.</param>
        ///  <param name="count">The number of times to repeat the string.</param>
        ///  <returns>A new string that is the input string repeated count times.</returns>
        public static string Repeat(this string input, int count)
        {
            if (input == null || count <= 0)
                return string.Empty;

            return string.Concat(Enumerable.Repeat(input, count));
        }

        /// <summary>
        /// Splits the string into lines by newline characters.
        /// </summary>
        /// <param name="input">The input string to split.</param>
        /// <returns>An array of strings, each representing a line from the input string.</returns>
        public static string[] SplitLines(this string input)
        {
            if (input == null)
                return Array.Empty<string>();

            return input.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }

        /// <summary>
        /// Splits the string into substrings of a given length.
        /// </summary>
        /// <param name="input">The input string to split.</param>
        /// <param name="length">The length of each substring.</param>
        /// <returns>An enumerable of substrings, each with the specified length.</returns>
        /// This method iterates through the input string in steps of the specified length,
        /// yielding substrings of that length until the end of the string is reached.
        public static IEnumerable<string> SplitByLength(this string input, int length)
        {
            if (string.IsNullOrEmpty(input) || length <= 0)
                yield break;

            for (int i = 0; i < input.Length; i += length)
                yield return input.Substring(i, Math.Min(length, input.Length - i));
        }

        /// <summary>
        /// Splits the string by length and joins substrings with a separator.
        /// </summary>
        /// <param name="input">The input string to split.</param>
        /// <param name="length">The length of each substring.</param>
        /// <param name="separator">The separator to use between substrings.</param>
        /// <returns>A single string with substrings joined by the specified separator.</returns>
        public static string SplitByLengthWithSeparator(this string input, int length, string separator)
        {
            return string.Join(separator, input.SplitByLength(length));
        }

        /// <summary>
        /// Splits the string by length, trims each part, and joins with separator.
        /// </summary>
        /// <param name="input">The input string to split.</param>
        /// <param name="length">The length of each substring.</param>
        /// <param name="separator">The separator to use between substrings.</param>
        /// <returns>A single string with trimmed substrings joined by the specified separator.</returns>
        public static string SplitByLengthWithSeparatorAndTrim(this string input, int length, string separator)
        {
            return string.Join(separator, input.SplitByLength(length).Select(x => x.Trim()));
        }

        /// <summary>
        /// Splits by length, trims each, removes empty parts, and joins with separator.
        /// </summary>
        /// <param name="input">The input string to split.</param>
        /// <param name="length">The length of each substring.</param>
        /// <param name="separator">The separator to use between substrings.</param>
        /// <returns>A single string with trimmed, non-empty substrings joined by the specified separator.</returns>
        public static string SplitByLengthWithSeparatorAndTrimAndRemoveEmpty(this string input, int length, string separator)
        {
            return string.Join(separator, input.SplitByLength(length).Select(x => x.Trim()).Where(x => !string.IsNullOrEmpty(x)));
        }

        /// <summary>
        /// Trims whitespace from the start and end of the string.
        /// </summary>
        /// <param name="input">The input string to trim.</param>
        /// <returns>A new string with leading and trailing whitespace removed.</returns>
        public static string TrimWhitespace(this string input) => input?.Trim() ?? string.Empty;

        /// <summary>
        /// Trims whitespace from the start and end of the string, returning null if the result is empty.
        /// </summary>
        /// <param name="input">The input string to trim.</param>
        /// <returns>A new string with leading and trailing whitespace removed, or null if the result is empty.</returns>
        public static string TrimToEmpty(this string input) => string.IsNullOrWhiteSpace(input) ? string.Empty : input.Trim();

        /// <summary>
        /// Trims whitespace from the start and end of the string, returning null if the result is empty.
        /// </summary>
        /// <param name="input">The input string to trim.</param>
        /// <returns>A new string with leading and trailing whitespace removed, or null if the result is empty.</returns>
        public static string? TrimToNull(this string input) => string.IsNullOrWhiteSpace(input) ? null : input.Trim();

        /// <summary>
        /// Trims whitespace from the start of the string.
        /// </summary>
        /// <param name="input">The input string to trim.</param>
        public static string TrimStartToEmpty(this string input) => string.IsNullOrWhiteSpace(input) ? string.Empty : input.TrimStart();

        /// <summary>
        /// Trims whitespace from the start of the string, returning null if the result is empty.
        /// </summary>
        /// <param name="input">The input string to trim.</param>
        public static string? TrimStartToNull(this string input) => string.IsNullOrWhiteSpace(input) ? null : input.TrimStart();

        /// <summary>
        /// Trims whitespace from the end of the string.
        /// </summary>
        /// <param name="input">The input string to trim.</param>
        public static string TrimEndToEmpty(this string input) => string.IsNullOrWhiteSpace(input) ? string.Empty : input.TrimEnd();
        /// <summary>
        /// Trims whitespace from the end of the string, returning null if the result is empty.
        /// </summary>
        /// <param name="input">The input string to trim.</param>
        public static string? TrimEndToNull(this string input) => string.IsNullOrWhiteSpace(input) ? null : input.TrimEnd();

        /// <summary>
        /// Normalizes all line endings in the string to the specified newline character(s).
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="newline">The newline string to normalize to. Default is "\n".</param>
        /// <returns>The string with normalized line endings.</returns>
        public static string NormalizeLineEndings(this string input, string newline = "\n")
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return Regex.Replace(input, @"\r\n|\r|\n", newline);
        }

        /// <summary>
        /// Replaces multiple consecutive whitespace characters with a single space.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The string with normalized spaces.</returns>
        public static string NormalizeSpaces(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return Regex.Replace(input, @"\s+", " ");
        }

    }
}
