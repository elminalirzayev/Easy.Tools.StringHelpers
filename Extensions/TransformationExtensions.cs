using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods for transforming strings (Slug, Initials, Reverse).
    /// </summary>
    public static class TransformationExtensions
    {
        // Regex compiled and static for performance with Timeouts to prevent ReDoS
        private static readonly TimeSpan RegexTimeout = TimeSpan.FromSeconds(2);

        private static readonly Regex RemoveInvalidCharsRegex = new(@"[^a-z0-9\s-]", RegexOptions.Compiled, RegexTimeout);
        private static readonly Regex CollapseSpacesRegex = new(@"\s+", RegexOptions.Compiled, RegexTimeout);
        private static readonly Regex CollapseHyphensRegex = new(@"-+", RegexOptions.Compiled, RegexTimeout);

        /// <summary>
        /// Converts the input string into a URL-friendly slug.
        /// Handles Turkish characters explicitly before normalization.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>
        /// A lowercase, hyphen-separated string suitable for use in URLs or filenames.
        /// Returns empty string if input is null.
        /// </returns>
        public static string GenerateSlug(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            // 1. Pre-handle specific characters (especially Turkish)
            // Note: Efficient replace chaining
            input = input.Replace("ı", "i").Replace("İ", "i");

            // 2. Normalize and remove diacritics
            string normalized = input.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder(normalized.Length);

            foreach (char c in normalized)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            string clean = sb.ToString().Normalize(NormalizationForm.FormC).ToLowerInvariant();

            // 3. Apply Regex operations efficiently
            try
            {
                clean = RemoveInvalidCharsRegex.Replace(clean, "");
                clean = CollapseSpacesRegex.Replace(clean, "-");
                clean = CollapseHyphensRegex.Replace(clean, "-");
            }
            catch (RegexMatchTimeoutException)
            {
                // Fallback or simple return in case of ReDoS attempt
                return string.Empty;
            }

            return clean.Trim('-');
        }

        /// <summary>
        /// Returns the initials (uppercase) from a full name string.
        /// Optimized to avoid memory allocations from string splitting.
        /// </summary>
        /// <param name="input">The input full name string.</param>
        /// <param name="maxInitials">Maximum number of initials to return. Default is all.</param>
        /// <returns>Initials in uppercase.</returns>
        public static string ToInitials(this string input, int? maxInitials = null)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            var sb = new StringBuilder(maxInitials ?? 5);
            bool isNextCharInitial = true;
            int count = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (maxInitials.HasValue && count >= maxInitials.Value) break;

                char c = input[i];

                if (char.IsWhiteSpace(c))
                {
                    isNextCharInitial = true;
                }
                else if (isNextCharInitial)
                {
                    if (char.IsLetter(c))
                    {
                        sb.Append(char.ToUpperInvariant(c));
                        count++;
                        isNextCharInitial = false;
                    }
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Reverses the given string.
        /// </summary>
        /// <param name="input">The string to reverse.</param>
        /// <returns>The reversed string.</returns>
        public static string Reverse(this string input)
        {
            if (string.IsNullOrEmpty(input)) return input ?? string.Empty;

#if NET6_0_OR_GREATER
            // Modern .NET: Zero allocation reverse using Span
            return string.Create(input.Length, input, (span, state) =>
            {
                state.AsSpan().CopyTo(span);
                span.Reverse();
            });
#else
            // Legacy .NET: Standard Array.Reverse
            char[] array = input.ToCharArray();
            Array.Reverse(array);
            return new string(array);
#endif
        }
    }
}