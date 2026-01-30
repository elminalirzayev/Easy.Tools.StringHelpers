using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods related to searching, checking, and extracting substrings.
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
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(toCheck)) return false;

#if NET6_0_OR_GREATER || NETSTANDARD2_1
            return source.Contains(toCheck, StringComparison.OrdinalIgnoreCase);
#else
            return source.IndexOf(toCheck, StringComparison.OrdinalIgnoreCase) >= 0;
#endif
        }

        /// <summary>
        /// Replaces all occurrences of oldValue with newValue, ignoring case.
        /// </summary>
        /// <param name="source">The source string.</param>
        /// <param name="oldValue">The substring to replace.</param>
        /// <param name="newValue">The replacement string.</param>
        /// <returns>A new string with replacements applied.</returns>
        public static string ReplaceIgnoreCase(this string source, string oldValue, string newValue)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(oldValue)) return source;
            if (newValue == null) newValue = string.Empty;

#if NET6_0_OR_GREATER || NETSTANDARD2_1
            // Modern .NET supports efficient case-insensitive replace without Regex
            return source.Replace(oldValue, newValue, StringComparison.OrdinalIgnoreCase);
#else
            // Fallback for legacy .NET
            return Regex.Replace(source, Regex.Escape(oldValue), newValue.Replace("$", "$$"), RegexOptions.IgnoreCase);
#endif
        }

        /// <summary>
        /// Counts how many times a character appears in the string.
        /// </summary>
        /// <param name="source">The string to search in.</param>
        /// <param name="c">The character to count.</param>
        /// <returns>The count of occurrences.</returns>
        public static int CountOccurrences(this string source, char c)
        {
            if (string.IsNullOrEmpty(source)) return 0;

            int count = 0;
            foreach (char ch in source)
            {
                if (ch == c) count++;
            }
            return count;
        }

        /// <summary>
        /// Returns true if the string is not null/empty and contains only numeric digits.
        /// </summary>
        /// <param name="source">The string to check.</param>
        /// <returns>True if numeric digits only.</returns>
        public static bool IsNumeric(this string source)
        {
            if (string.IsNullOrEmpty(source)) return false;

            foreach (char c in source)
            {
                if (!char.IsDigit(c)) return false;
            }
            return true;
        }

        /// <summary>
        /// Extracts and returns only digit characters from the string.
        /// </summary>
        /// <param name="source">The string to extract digits from.</param>
        /// <returns>String containing only digits.</returns>
        public static string ExtractDigits(this string source)
        {
            if (string.IsNullOrEmpty(source)) return string.Empty;

            var sb = new StringBuilder(source.Length);
            foreach (char ch in source)
            {
                if (char.IsDigit(ch))
                    sb.Append(ch);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Checks if the input string contains ANY of the specified values.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="comparison">Comparison type (default: Ordinal).</param>
        /// <param name="values">Array of strings to look for.</param>
        public static bool ContainsAny(this string input, StringComparison comparison = StringComparison.Ordinal, params string[] values)
        {
            if (string.IsNullOrEmpty(input) || values == null || values.Length == 0) return false;

#if NET6_0_OR_GREATER || NETSTANDARD2_1
            foreach (var value in values)
            {
                if (!string.IsNullOrEmpty(value) && input.Contains(value, comparison))
                    return true;
            }
            return false;
#else
            // Legacy fallback for comparison support
            foreach (var value in values)
            {
                if (!string.IsNullOrEmpty(value) && input.IndexOf(value, comparison) >= 0)
                    return true;
            }
            return false;
#endif
        }

        // Overload for backward compatibility (defaults to Ordinal)
        public static bool ContainsAny(this string input, params string[] values) =>
            ContainsAny(input, StringComparison.Ordinal, values);

        /// <summary>
        /// Checks if the input string contains ALL of the specified values.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="comparison">Comparison type (default: Ordinal).</param>
        /// <param name="values">Array of strings to look for.</param>
        public static bool ContainsAll(this string input, StringComparison comparison = StringComparison.Ordinal, params string[] values)
        {
            if (string.IsNullOrEmpty(input) || values == null || values.Length == 0) return false;

#if NET6_0_OR_GREATER || NETSTANDARD2_1
            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value) || !input.Contains(value, comparison))
                    return false;
            }
            return true;
#else
            foreach (var value in values)
            {
                if (string.IsNullOrEmpty(value) || input.IndexOf(value, comparison) < 0)
                    return false;
            }
            return true;
#endif
        }

        // Overload for backward compatibility
        public static bool ContainsAll(this string input, params string[] values) =>
            ContainsAll(input, StringComparison.Ordinal, values);

        /// <summary>
        /// Compares two strings for equality ignoring case.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="other">The string to compare with.</param>
        /// <returns>True if strings are equal ignoring case; otherwise, false.</returns>
        public static bool EqualsIgnoreCase(this string input, string other) =>
            string.Equals(input, other, StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// Checks if the input string starts with the specified value ignoring case.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="value">The value to check.</param>
        /// <returns>True if starts with the value; otherwise, false.</returns>
        public static bool StartsWithIgnoreCase(this string input, string value)
        {
            if (input == null || value == null) return false;
            return input.StartsWith(value, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Checks if the input string ends with the specified value ignoring case.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="value">The value to check.</param>
        /// <returns>True if ends with the value; otherwise, false.</returns>
        public static bool EndsWithIgnoreCase(this string input, string value)
        {
            if (input == null || value == null) return false;
            return input.EndsWith(value, StringComparison.OrdinalIgnoreCase);
        }
    }
}