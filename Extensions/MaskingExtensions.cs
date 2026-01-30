using System;
using System.Text;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods for masking sensitive information.
    /// </summary>
    public static class MaskingExtensions
    {
        /// <summary>
        /// Masks an email address (e.g., "johndoe@example.com" -> "j*****@example.com").
        /// </summary>
        /// <param name="email">The email address to mask.</param>
        /// <returns>Masked email string.</returns>
        public static string MaskEmail(this string email)
        {
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@")) return email ?? string.Empty;

            var parts = email.Split('@');
            var localPart = parts[0];
            var domainPart = parts[1];

            if (localPart.Length <= 2)
                return $"{localPart[0]}***@{domainPart}";

            // Optimization: Avoid string concatenation loop
            return $"{localPart.Substring(0, 2)}{new string('*', localPart.Length - 2)}@{domainPart}";
        }

        /// <summary>
        /// Masks all characters except the last visibleCount characters.
        /// Example: "123456789", 4 -> "*****6789".
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="visibleCount">Number of visible characters at the end.</param>
        /// <param name="maskChar">Character to use for masking.</param>
        /// <returns>Masked string.</returns>
        public static string MaskLeft(this string input, int visibleCount = 4, char maskChar = '*')
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            if (input.Length <= visibleCount) return input;

            int maskLength = input.Length - visibleCount;
            return new string(maskChar, maskLength) + input.Substring(maskLength);
        }

        /// <summary>
        /// Masks all characters except the first visibleCount characters.
        /// Example: "123456789", 4 -> "1234*****".
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="visibleCount">Number of visible characters at the start.</param>
        /// <param name="maskChar">Character to use for masking.</param>
        /// <returns>Masked string.</returns>
        public static string MaskRight(this string input, int visibleCount = 4, char maskChar = '*')
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            if (input.Length <= visibleCount) return input;

            return input.Substring(0, visibleCount) + new string(maskChar, input.Length - visibleCount);
        }
    }
}