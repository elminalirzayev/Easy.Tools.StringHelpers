using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods related to formatting strings.
    /// </summary>
    public static class FormatExtensions
    {
        /// <summary>
        /// Converts a string to snake_case format.
        /// Example: "HelloWorld" -> "hello_world"
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The snake_case formatted string.</returns>
        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var startUnderscores = Regex.Match(input, @"^_+");
            string result = Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
            return startUnderscores + result;
        }

        /// <summary>
        /// Converts a string to kebab-case format.
        /// Example: "HelloWorld" -> "hello-world"
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The kebab-case formatted string.</returns>
        /// This method uses a regular expression to find positions where a lowercase letter is followed by an uppercase letter,
        /// and inserts a hyphen between them. It also converts the entire string to lowercase.
        public static string ToKebabCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var startHyphens = Regex.Match(input, @"^-+");
            string result = Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1-$2").ToLower();
            return startHyphens + result;
        }

        /// <summary>
        /// Splits camelCase or PascalCase string into words separated by space.
        /// Example: "CamelCaseString" -> "Camel Case String"
        /// </summary>
        ///  <param name="input">The input string to split.</param>
        ///  <returns>The string with words separated by space.</returns>
        ///  This method uses a regular expression to find positions where a lowercase letter is followed by an uppercase letter,
        ///  and inserts a space between them.
        public static string SplitCamelCase(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return Regex.Replace(input, "([a-z])([A-Z])", "$1 $2");
        }

        /// <summary>
        /// Removes diacritical marks (accents) from the string.
        /// Example: "áéíóú" -> "aeiou"
        /// </summary>
        ///  <param name="input">The input string to process.</param>
        ///  <returns>The string without diacritical marks.</returns>
        ///  This method normalizes the string to FormD, removes non-spacing marks,
        ///  and then normalizes it back to FormC.
        public static string RemoveDiacritics(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var normalized = input.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var ch in normalized)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(ch);
                }
            }
            return sb.ToString().Normalize(NormalizationForm.FormC);
        }
    }
}
