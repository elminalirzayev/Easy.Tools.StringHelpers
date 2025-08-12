using System.Text;
using System.Text.RegularExpressions;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods related to searching and checking substrings.
    /// </summary>
    public static class SearchExtensions
    {
        /// <summary>
        /// Checks if the source string contains the specified substring, ignoring case.
        /// </summary>
        /// <param name="source">The source string to search in.</param>
        /// <param name="toCheck">The substring to search for.</param>
        /// <returns>True if the substring is found; otherwise, false.</returns>

        public static bool ContainsIgnoreCase(this string source, string toCheck)
        {
            if (source == null || toCheck == null)
                return false;
            return source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
        }

        /// <summary>
        /// Replaces all occurrences of oldValue with newValue, ignoring case.
        /// </summary>
        /// <param name="source">The source string to perform replacements on.</param>
        /// <param name="oldValue">The substring to replace.</param>
        /// <param name="newValue">The replacement string.</param>
        /// <returns>A new string with replacements applied.</returns>
        public static string? ReplaceIgnoreCase(this string source, string oldValue, string newValue)
        {
            if (source == null || oldValue == null || newValue == null)
                return source;

            return Regex.Replace(source, Regex.Escape(oldValue), newValue.Replace("$", "$$"), RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// Counts how many times a character appears in the string.
        /// </summary>
        /// <param name="source">The string to search in.</param>
        /// <param name="c">The character to count.</param>
        /// <returns>The count of occurrences of the character.</returns>
        public static int CountOccurrences(this string source, char c)
        {
            if (string.IsNullOrEmpty(source))
                return 0;

            int count = 0;
            foreach (var ch in source)
                if (ch == c)
                    count++;
            return count;
        }

        /// <summary>
        /// Returns true if all characters in the string are numeric digits.
        /// </summary>
        /// <param name="source">The string to check.</param>
        /// <returns>True if the string contains only numeric digits; otherwise, false.</returns>
        public static bool IsNumeric(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return false;

            return source.All(char.IsDigit);
        }

        /// <summary>
        /// Extracts and returns only digit characters from the string.
        /// </summary>
        /// <param name="source">The string to extract digits from.</param>
        /// <returns>A string containing only the digit characters from the source string.</returns>
        public static string ExtractDigits(this string source)
        {
            if (string.IsNullOrEmpty(source))
                return string.Empty;

            var sb = new StringBuilder();
            foreach (var ch in source)
                if (char.IsDigit(ch))
                    sb.Append(ch);
            return sb.ToString();
        }

        /// <summary>
        /// Checks if the input string contains any of the specified values.
        /// </summary>
        /// <param name="input">The input string to search in.</param>
        /// <param name="values">The array of strings to look for.</param>
        /// <returns>True if any value is found; otherwise, false.</returns>
        public static bool ContainsAny(this string input, params string[] values)
        {
            if (input == null || values == null || values.Length == 0)
                return false;

            return values.Any(value => !string.IsNullOrEmpty(value) && input.Contains(value));
        }

        /// <summary>
        /// Checks if the input string contains all of the specified values.
        /// </summary>
        /// <param name="input">The input string to search in.</param>
        /// <param name="values">The array of strings to look for.</param>
        /// <returns>True if all values are found; otherwise, false.</returns>
        public static bool ContainsAll(this string input, params string[] values)
        {
            if (input == null || values == null || values.Length == 0)
                return false;

            return values.All(value => !string.IsNullOrEmpty(value) && input.Contains(value));
        }

        /// <summary>
        /// Compares two strings for equality ignoring case.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="other">The string to compare with.</param>
        /// <returns>True if strings are equal ignoring case; otherwise, false.</returns>
        public static bool EqualsIgnoreCase(this string input, string other)
        {
            return string.Equals(input, other, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Checks if the input string starts with the specified value ignoring case.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="value">The value to check for at the start.</param>
        /// <returns>True if input starts with value ignoring case; otherwise, false.</returns>
        public static bool StartsWithIgnoreCase(this string input, string value)
        {
            if (input == null || value == null)
                return false;

            return input.StartsWith(value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Checks if the input string ends with the specified value ignoring case.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="value">The value to check for at the end.</param>
        /// <returns>True if input ends with value ignoring case; otherwise, false.</returns>
        public static bool EndsWithIgnoreCase(this string input, string value)
        {
            if (input == null || value == null)
                return false;

            return input.EndsWith(value, StringComparison.OrdinalIgnoreCase);
        }


    }

}
