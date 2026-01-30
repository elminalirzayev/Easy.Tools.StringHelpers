using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Linq;
using System.Xml;

#if NET8_0_OR_GREATER || NET7_0_OR_GREATER || NET6_0_OR_GREATER 
using System.Text.Json;
#endif

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods related to string validation (Email, URL, JSON, Credit Card, etc.).
    /// </summary>
    public static class ValidationExtensions
    {
        // Pre-compiled regex patterns with timeouts for ReDoS protection
        private static readonly TimeSpan RegexTimeout = TimeSpan.FromSeconds(2);

        private static readonly Regex _emailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase, RegexTimeout);

        private static readonly Regex _urlRegex = new Regex(
            @"^(http|https):\/\/[^\s$.?#].[^\s]*$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase, RegexTimeout);

        private static readonly Regex _hexColorRegex = new Regex(
            @"^#(?:[0-9a-fA-F]{3}){1,2}$",
            RegexOptions.Compiled, RegexTimeout);

        private static readonly Regex _phoneRegex = new Regex(
            @"^\+?\d{7,15}$",
            RegexOptions.Compiled, RegexTimeout);

        /// <summary>
        /// Checks if a string is a palindrome (reads the same forwards and backwards).
        /// Ignores case and non-alphanumeric characters.
        /// </summary>
        /// <param name="input">The input string to check.</param>
        /// <returns><c>true</c> if the string is a palindrome; otherwise, <c>false</c>.</returns>
        public static bool IsPalindrome(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            int min = 0;
            int max = input.Length - 1;

            while (min < max)
            {
                char a = input[min];
                char b = input[max];

                // Skip non-alphanumeric characters
                if (!char.IsLetterOrDigit(a)) { min++; continue; }
                if (!char.IsLetterOrDigit(b)) { max--; continue; }

                if (char.ToLowerInvariant(a) != char.ToLowerInvariant(b)) return false;

                min++;
                max--;
            }
            return true;
        }

        /// <summary>
        /// Validates if the input is a properly formatted email address.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns><c>true</c> if the string is a valid email format; otherwise, <c>false</c>.</returns>
        public static bool IsValidEmail(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            try
            {
                return _emailRegex.IsMatch(input);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        /// <summary>
        /// Validates if the input is a valid absolute URL (HTTP or HTTPS).
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns><c>true</c> if the string is a valid URL; otherwise, <c>false</c>.</returns>
        public static bool IsValidUrl(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            return Uri.TryCreate(input, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        /// <summary>
        /// Validates if the input is a valid GUID (Globally Unique Identifier).
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns><c>true</c> if the string is a valid GUID; otherwise, <c>false</c>.</returns>
        public static bool IsValidGuid(this string input) => Guid.TryParse(input, out _);

        /// <summary>
        /// Validates if the input string can be parsed as a valid DateTime.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns><c>true</c> if the string is a valid date; otherwise, <c>false</c>.</returns>
        public static bool IsValidDate(this string input) => DateTime.TryParse(input, out _);

        /// <summary>
        /// Validates if the input is a valid JSON string.
        /// Checks for valid structure ({...} or [...]).
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns><c>true</c> if the string is valid JSON; otherwise, <c>false</c>.</returns>
        public static bool IsValidJson(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            var trimmed = input.Trim();

            // Fast fail check
            if (!(trimmed.StartsWith("{") && trimmed.EndsWith("}")) &&
                !(trimmed.StartsWith("[") && trimmed.EndsWith("]"))) return false;

#if NET6_0_OR_GREATER
            try
            {
                JsonDocument.Parse(trimmed);
                return true;
            }
            catch
            {
                return false;
            }
#else
            // JSON validation is complex in legacy without external libraries like Newtonsoft.
            // Returning false to be safe/consistent, or implement a basic stack-based checker if strictly needed.
            return false; 
#endif
        }

        /// <summary>
        /// Validates if the input is a valid XML string.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns><c>true</c> if the string is valid XML; otherwise, <c>false</c>.</returns>
        public static bool IsValidXml(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            try
            {
                var settings = new XmlReaderSettings { DtdProcessing = DtdProcessing.Prohibit };
                using var reader = XmlReader.Create(new System.IO.StringReader(input), settings);
                while (reader.Read()) { }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validates if the input is a valid Base64 encoded string.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns><c>true</c> if the string is valid Base64; otherwise, <c>false</c>.</returns>
        public static bool IsValidBase64(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            input = input.Trim();
            if (input.Length % 4 != 0) return false;

#if NET6_0_OR_GREATER
            Span<byte> buffer = new byte[input.Length];
            return Convert.TryFromBase64String(input, buffer, out _);
#else
            try
            {
                Convert.FromBase64String(input);
                return true;
            }
            catch
            {
                return false;
            }
#endif
        }

        /// <summary>
        /// Validates if the input is a valid IP address (IPv4 or IPv6).
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns><c>true</c> if the string is a valid IP address; otherwise, <c>false</c>.</returns>
        public static bool IsValidIpAddress(this string input) => IPAddress.TryParse(input, out _);

        /// <summary>
        /// Validates if the input is a valid credit card number using the Luhn algorithm.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns><c>true</c> if the string is a valid credit card number; otherwise, <c>false</c>.</returns>
        public static bool IsValidCreditCard(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            int sum = 0;
            bool alternate = false;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                char c = input[i];

                if (char.IsWhiteSpace(c) || c == '-') continue;
                if (!char.IsDigit(c)) return false;

                int n = c - '0';

                if (alternate)
                {
                    n *= 2;
                    if (n > 9) n -= 9;
                }

                sum += n;
                alternate = !alternate;
            }

            return sum > 0 && sum % 10 == 0;
        }

        /// <summary>
        /// Validates if the input is a valid Hex Color code (e.g., #FFF or #FFFFFF).
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns><c>true</c> if the string is a valid hex color; otherwise, <c>false</c>.</returns>
        public static bool IsValidHexColor(this string input) =>
            !string.IsNullOrEmpty(input) && _hexColorRegex.IsMatch(input);

        /// <summary>
        /// Validates if the input is a valid phone number (basic international format check).
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns><c>true</c> if the string is a valid phone number; otherwise, <c>false</c>.</returns>
        public static bool IsValidPhoneNumber(this string input) =>
            !string.IsNullOrEmpty(input) && _phoneRegex.IsMatch(input);

        /// <summary>
        /// Validates if the password meets specified complexity requirements.
        /// </summary>
        /// <param name="input">The password string to validate.</param>
        /// <param name="minLength">Minimum required length (default: 8).</param>
        /// <param name="requireSpecialChar">Require at least one special character (default: false).</param>
        /// <param name="requireDigit">Require at least one numeric digit (default: false).</param>
        /// <param name="requireUppercase">Require at least one uppercase letter (default: false).</param>
        /// <param name="requireLowercase">Require at least one lowercase letter (default: false).</param>
        /// <returns><c>true</c> if the password meets all criteria; otherwise, <c>false</c>.</returns>
        public static bool IsValidPassword(this string input, int minLength = 8, bool requireSpecialChar = false, bool requireDigit = false, bool requireUppercase = false, bool requireLowercase = false)
        {
            if (string.IsNullOrEmpty(input) || input.Length < minLength) return false;

            if (requireDigit && !input.Any(char.IsDigit)) return false;
            if (requireUppercase && !input.Any(char.IsUpper)) return false;
            if (requireLowercase && !input.Any(char.IsLower)) return false;
            if (requireSpecialChar && !input.Any(ch => !char.IsLetterOrDigit(ch))) return false;

            return true;
        }

        /// <summary>
        /// Validates if the input is a valid username.
        /// Allows alphanumeric characters, underscores, hyphens, and dots.
        /// </summary>
        /// <param name="input">The username string to validate.</param>
        /// <param name="minLength">Minimum allowed length (default: 3).</param>
        /// <param name="maxLength">Maximum allowed length (default: 20).</param>
        /// <returns><c>true</c> if the username is valid; otherwise, <c>false</c>.</returns>
        public static bool IsValidUsername(this string input, int minLength = 3, int maxLength = 20)
        {
            if (string.IsNullOrEmpty(input) || input.Length < minLength || input.Length > maxLength) return false;

            foreach (char c in input)
            {
                if (!char.IsLetterOrDigit(c) && c != '_' && c != '-' && c != '.') return false;
            }
            return true;
        }
    }
}