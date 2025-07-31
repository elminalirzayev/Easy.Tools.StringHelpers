using System.Text.RegularExpressions;
namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods related to sanitizing strings.
    /// </summary>
    public static class SanitizeExtensions
    {
        /// <summary>
        /// Removes all HTML tags from the string.
        /// </summary>
        /// <param name="input">The input string containing HTML content.</param>
        /// <returns>A string with all HTML tags removed.</returns>
        /// This method uses a regular expression to match HTML tags and replaces them with an empty string.
        /// If the input string is null or empty, it returns an empty string.
        public static string StripHtmlTags(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            return Regex.Replace(input, "<.*?>", string.Empty);
        }

        /// <summary>
        /// Removes all special characters except letters and digits.
        /// </summary>
        /// <param name="input">The input string to sanitize.</param>
        /// <returns>A string with all special characters removed, leaving only letters and digits.</returns>
        /// This method uses a regular expression to match any character that is not a letter or digit
        /// and replaces it with an empty string.
        public static string RemoveSpecialCharacters(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            return Regex.Replace(input, @"[^a-zA-Z0-9]", string.Empty);
        }

        /// <summary>
        /// Removes all digit characters from the string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The string without digits.</returns>
        public static string RemoveDigits(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return Regex.Replace(input, @"\d", "");
        }

        /// <summary>
        /// Removes all letter characters from the string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The string without letters.</returns>
        public static string RemoveLetters(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return Regex.Replace(input, @"[a-zA-Z]", "");
        }

        /// <summary>
        /// Removes all non-ASCII characters from the string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The string containing only ASCII characters.</returns>
        public static string RemoveNonAscii(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return Regex.Replace(input, @"[^\x00-\x7F]", "");
        }

        /// <summary>
        /// Removes all punctuation characters from the string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The string without punctuation.</returns>
        public static string RemovePunctuation(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            return Regex.Replace(input, @"[\p{P}]", "");
        }

    }

}