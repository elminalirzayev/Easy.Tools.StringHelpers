using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods related to random string generation.
    /// </summary>
    public static class GenerationExtensions
    {
        private static readonly Random _random = new();

        /// <summary>
        /// Generates a random alphanumeric string of the specified length.
        /// </summary>
        /// <param name="length">The length of the string to generate.</param>
        /// <returns>A random string.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if length is less than or equal to zero.</exception>
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            if (length <= 0)
                return string.Empty;

            var sb = new StringBuilder(length);
            for (int i = 0; i < length; i++)
                sb.Append(chars[_random.Next(chars.Length)]);
            return sb.ToString();
        }

        /// <summary>
        /// Converts the input string into a URL-friendly slug.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>
        /// A lowercase, hyphen-separated string suitable for use in URLs or filenames.
        /// If the input is null or whitespace, returns an empty string.
        /// </returns>
        public static string GenerateSlug(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

            // Normalize and remove diacritics
            string normalized = input.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (char c in normalized)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            string clean = sb.ToString().Normalize(NormalizationForm.FormC);

            // Lowercase, replace spaces, remove invalid chars
            clean = Regex.Replace(clean.ToLowerInvariant(), @"[^a-z0-9\s-]", "");
            clean = Regex.Replace(clean, @"\s+", "-").Trim('-');
            clean = Regex.Replace(clean, @"-+", "-");

            return clean;
        }

        /// <summary>
        /// Returns the initials (uppercase) from a full name string.
        /// </summary>
        /// <param name="input">The input full name string.</param>
        /// <returns>Initials in uppercase, or empty string if input is null or empty.</returns>
        public static string ToInitials(this string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                return string.Empty;

#if NET8_0_OR_GREATER || NET7_0_OR_GREATER || NET6_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
            var words = input.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
#else
            var words = input.Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
#endif

            var initials = string.Concat(words.Select(w => char.ToUpperInvariant(w[0])));
            return initials;
        }

    }

}
