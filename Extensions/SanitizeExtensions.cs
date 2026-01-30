using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods related to sanitizing strings by removing unwanted characters.
    /// </summary>
    public static class SanitizeExtensions
    {
        // Compiled Regex with Timeout for security (ReDoS protection)
        private static readonly Regex _htmlTagRegex = new Regex("<.*?>", RegexOptions.Compiled, TimeSpan.FromSeconds(2));

        /// <summary>
        /// Removes all HTML tags from the string.
        /// </summary>
        /// <param name="input">The input string containing HTML content.</param>
        /// <returns>A string with all HTML tags removed.</returns>
        public static string StripHtmlTags(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            try
            {
                return _htmlTagRegex.Replace(input, string.Empty);
            }
            catch (RegexMatchTimeoutException)
            {
                return string.Empty; // Fail safe
            }
        }

        /// <summary>
        /// Removes all special characters, leaving only letters and digits.
        /// Optimized using character loop instead of Regex for performance.
        /// </summary>
        /// <param name="input">The input string to sanitize.</param>
        /// <returns>Alphanumeric string.</returns>
        public static string RemoveSpecialCharacters(this string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            var sb = new StringBuilder(input.Length);
            foreach (char c in input)
            {
                if (char.IsLetterOrDigit(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Removes all digit characters from the string.
        /// Optimized using character loop.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The string without digits.</returns>
        public static string RemoveDigits(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input ?? string.Empty;

            var sb = new StringBuilder(input.Length);
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Removes all letter characters from the string.
        /// Optimized using character loop.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The string without letters.</returns>
        public static string RemoveLetters(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input ?? string.Empty;

            var sb = new StringBuilder(input.Length);
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Removes all non-ASCII characters from the string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The string containing only ASCII characters.</returns>
        public static string RemoveNonAscii(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input ?? string.Empty;

            var sb = new StringBuilder(input.Length);
            foreach (char c in input)
            {
                if (c <= 127) // ASCII range is 0-127
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// Removes all punctuation characters from the string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The string without punctuation.</returns>
        public static string RemovePunctuation(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input ?? string.Empty;

            var sb = new StringBuilder(input.Length);
            foreach (char c in input)
            {
                if (!char.IsPunctuation(c))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}