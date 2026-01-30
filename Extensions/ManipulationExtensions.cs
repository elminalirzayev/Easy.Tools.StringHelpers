using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods related to string manipulation and formatting.
    /// </summary>
    public static class ManipulationExtensions
    {
        // Pre-compiled Regex patterns for better performance
        private static readonly Regex _normalizeSpaceRegex = new(@"\s+", RegexOptions.Compiled);
        private static readonly Regex _normalizeLineRegex = new(@"\r\n|\r|\n", RegexOptions.Compiled);
        private static readonly string[] _lineSeparators = { "\r\n", "\r", "\n" };

        /// <summary>
        /// Removes all whitespace characters from the string using a fast character loop.
        /// </summary>
        /// <param name="input">The input string to process.</param>
        /// <returns>The string with all whitespace removed.</returns>
        public static string RemoveWhitespace(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;

            // Performance Optimization: Using StringBuilder loop is faster than Regex for simple removal
            var sb = new StringBuilder(input.Length);
            foreach (char c in input)
            {
                if (!char.IsWhiteSpace(c))
                    sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Repeats the string a specified number of times using StringBuilder.
        /// </summary>
        /// <param name="input">The input string to repeat.</param>
        /// <param name="count">The number of times to repeat the string.</param>
        /// <returns>A new string that is the input string repeated count times.</returns>
        public static string Repeat(this string input, int count)
        {
            if (string.IsNullOrEmpty(input) || count <= 0) return string.Empty;

            var sb = new StringBuilder(input.Length * count);
            for (int i = 0; i < count; i++)
            {
                sb.Append(input);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Splits the string into lines by newline characters (\r\n, \r, \n).
        /// </summary>
        /// <param name="input">The input string to split.</param>
        /// <returns>An array of strings, each representing a line from the input string.</returns>
        public static string[] SplitLines(this string input)
        {
            if (input == null) return Array.Empty<string>();

            // Uses cached separator array to avoid memory allocation on every call
            return input.Split(_lineSeparators, StringSplitOptions.None);
        }

        /// <summary>
        /// Splits the string into substrings of a given length.
        /// </summary>
        /// <param name="input">The input string to split.</param>
        /// <param name="length">The length of each substring.</param>
        /// <returns>An enumerable of substrings.</returns>
        public static IEnumerable<string> SplitByLength(this string input, int length)
        {
            if (string.IsNullOrEmpty(input) || length <= 0)
                yield break;

            for (int i = 0; i < input.Length; i += length)
            {
                yield return input.Substring(i, Math.Min(length, input.Length - i));
            }
        }

        /// <summary>
        /// Splits the string by length and joins substrings with a separator.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="length">The chunk length.</param>
        /// <param name="separator">The separator string.</param>
        /// <returns>Joined string.</returns>
        public static string SplitByLengthWithSeparator(this string input, int length, string separator)
        {
            return string.Join(separator, input.SplitByLength(length));
        }

        /// <summary>
        /// Splits the string by length, trims each part, and joins with separator.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="length">The chunk length.</param>
        /// <param name="separator">The separator string.</param>
        /// <returns>Joined trimmed string.</returns>
        public static string SplitByLengthWithSeparatorAndTrim(this string input, int length, string separator)
        {
            return string.Join(separator, input.SplitByLength(length).Select(x => x.Trim()));
        }

        /// <summary>
        /// Splits by length, trims each, removes empty parts, and joins with separator.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="length">The chunk length.</param>
        /// <param name="separator">The separator string.</param>
        /// <returns>Joined cleaned string.</returns>
        public static string SplitByLengthWithSeparatorAndTrimAndRemoveEmpty(this string input, int length, string separator)
        {
            return string.Join(separator, input.SplitByLength(length)
                                              .Select(x => x.Trim())
                                              .Where(x => !string.IsNullOrEmpty(x)));
        }

        /// <summary>
        /// Trims whitespace from the string. Returns Empty string if input is null.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>Trimmed string or string.Empty.</returns>
        public static string TrimToEmpty(this string input) => string.IsNullOrWhiteSpace(input) ? string.Empty : input.Trim();

        /// <summary>
        /// Trims whitespace from the string. Returns null if result is empty or whitespace.
        /// Useful for database inserts where you want null instead of "".
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>Trimmed string or null.</returns>
        public static string? TrimToNull(this string input) => string.IsNullOrWhiteSpace(input) ? null : input.Trim();

        /// <summary>
        /// Trims whitespace from the start. Returns Empty string if input is null.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>Trimmed string.</returns>
        public static string TrimStartToEmpty(this string input) => string.IsNullOrWhiteSpace(input) ? string.Empty : input.TrimStart();

        /// <summary>
        /// Trims whitespace from the start. Returns null if result is empty.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>Trimmed string or null.</returns>
        public static string? TrimStartToNull(this string input) => string.IsNullOrWhiteSpace(input) ? null : input.TrimStart();

        /// <summary>
        /// Trims whitespace from the end. Returns Empty string if input is null.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>Trimmed string.</returns>
        public static string TrimEndToEmpty(this string input) => string.IsNullOrWhiteSpace(input) ? string.Empty : input.TrimEnd();

        /// <summary>
        /// Trims whitespace from the end. Returns null if result is empty.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>Trimmed string or null.</returns>
        public static string? TrimEndToNull(this string input) => string.IsNullOrWhiteSpace(input) ? null : input.TrimEnd();

        /// <summary>
        /// Normalizes all line endings in the string to the specified newline character.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="newline">The newline string to use (default is \n).</param>
        /// <returns>Normalized string.</returns>
        public static string NormalizeLineEndings(this string input, string newline = "\n")
        {
            if (string.IsNullOrEmpty(input)) return input;
            return _normalizeLineRegex.Replace(input, newline);
        }

        /// <summary>
        /// Replaces multiple consecutive whitespace characters with a single space.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>Normalized string.</returns>
        public static string NormalizeSpaces(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            return _normalizeSpaceRegex.Replace(input, " ").Trim();
        }

        /// <summary>
        /// Truncates the string to a specified length and appends an ellipsis (...) if necessary.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="maxLength">Maximum allowed length.</param>
        /// <param name="suffix">The suffix to append (default: "...").</param>
        /// <returns>Truncated string.</returns>
        public static string Truncate(this string input, int maxLength, string suffix = "...")
        {
            if (string.IsNullOrEmpty(input) || input.Length <= maxLength)
                return input;

            int effectiveLength = maxLength - suffix.Length;
            if (effectiveLength <= 0) return suffix.Substring(0, maxLength);

            return input.Substring(0, effectiveLength) + suffix;
        }

        /// <summary>
        /// Reverses the order of characters in the string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>Reversed string.</returns>
        public static string Reverse(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input;
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}