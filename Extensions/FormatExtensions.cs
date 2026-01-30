using System;
using System.Globalization;
using System.Text;
using System.Linq;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods related to string formatting and casing conversions.
    /// </summary>
    public static class FormatExtensions
    {
        /// <summary>
        /// Converts a string to snake_case format (e.g., "HelloWorld" -> "hello_world").
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The snake_case formatted string.</returns>
        public static string ToSnakeCase(this string input) => ConvertCase(input, '_');

        /// <summary>
        /// Converts a string to kebab-case format (e.g., "HelloWorld" -> "hello-world").
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The kebab-case formatted string.</returns>
        public static string ToKebabCase(this string input) => ConvertCase(input, '-');

        /// <summary>
        /// Splits a CamelCase string into words separated by spaces (e.g., "CamelCase" -> "Camel Case").
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The spaced string.</returns>
        public static string SplitCamelCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            var sb = new StringBuilder(input.Length + 5);
            for (int i = 0; i < input.Length; i++)
            {
                if (i > 0 && char.IsUpper(input[i]))
                    sb.Append(' ');
                sb.Append(input[i]);
            }
            return sb.ToString();
        }

        /// <summary>
        /// Removes diacritical marks (accents) from the string.
        /// Example: "áéíóú" -> "aeiou".
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The string without diacritics.</returns>
        public static string RemoveDiacritics(this string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            var normalized = input.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder(normalized.Length);

            foreach (var c in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return sb.ToString().Normalize(NormalizationForm.FormC);
        }

        private static string ConvertCase(string input, char separator)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

#if NET6_0_OR_GREATER
            // Modern efficient implementation using string.Create to avoid allocations
            // We estimate length: original + roughly 20% for separators
            int estimatedLength = input.Length + (input.Length / 5);

            // Note: Since we don't know exact length, StringBuilder is actually safer/easier 
            // unless we do a two-pass scan. For simplicity and robustness across generic inputs:
#endif
            var sb = new StringBuilder(input.Length + 5);
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];
                if (char.IsUpper(c))
                {
                    if (i > 0 && input[i - 1] != separator && !char.IsUpper(input[i - 1]))
                    {
                        sb.Append(separator);
                    }
                    sb.Append(char.ToLowerInvariant(c));
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }
    }
}