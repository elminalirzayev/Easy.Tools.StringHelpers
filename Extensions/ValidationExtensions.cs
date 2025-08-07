using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Xml;
#if NET8_0_OR_GREATER || NET7_0_OR_GREATER || NET6_0_OR_GREATER 
using System.Text.Json;
#endif

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods related to validation.
    /// </summary>
    public static class ValidationExtensions
    {
        /// <summary>
        /// Checks if a string is a palindrome (ignores case and whitespace).
        /// </summary>
        /// <param name="input">The input string to check.</param>
        /// <returns>True if the string is a palindrome; otherwise, false.</returns>
        public static bool IsPalindrome(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return false;

            var cleaned = Regex.Replace(input.ToLower(), @"\s+", "");
            int len = cleaned.Length;

            for (int i = 0; i < len / 2; i++)
            {
                if (cleaned[i] != cleaned[len - i - 1])
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Validates if the input is a properly formatted email.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>True if the string is a valid email; otherwise, false.</returns>
        /// This method uses the MailAddress class to attempt to create a new email address object.
        /// If the input is not a valid email format, it will throw an exception, which we catch to return false.
        public static bool IsValidEmail(this string input)
        {
            try
            {
                _ = new MailAddress(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validates if the input is a valid URL.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>True if the string is a valid URL; otherwise, false.</returns>
        /// This method uses the Uri.TryCreate method to check if the input can be parsed as a valid absolute URL.
        public static bool IsValidUrl(this string input)
        {
            return Uri.TryCreate(input, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        /// <summary>
        /// Validates if the input is a valid GUID.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>True if the string is a valid GUID; otherwise, false.</returns>
        public static bool IsValidGuid(this string input)
        {
            return Guid.TryParse(input, out _);
        }

        /// <summary>
        /// Validates if the input is a valid date.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>True if the string can be parsed as a date; otherwise, false.</returns>
        public static bool IsValidDate(this string input)
        {
            return DateTime.TryParse(input, out _);
        }

        /// <summary>
        /// Validates if the input is a valid JSON string.
        /// </summary>
#if NET8_0_OR_GREATER || NET7_0_OR_GREATER || NET6_0_OR_GREATER

        /// <param name="input">The input string to validate.</param>
        /// <returns>True if the string is a valid JSON; otherwise, false.</returns>
        public static bool IsValidJson(this string input)
        {
            try
            {
                JsonDocument.Parse(input);
                return true;
            }
            catch
            {
                return false;
            }
        }
#else
        /// <param name="input">The input string to validate.</param>
        /// <returns>Always returns false; JSON validation not supported on this framework.</returns>
        public static bool IsValidJson(this string input)
        {
            return false;
        }
#endif

        /// <summary>
        /// Validates if the input is a valid XML string.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>True if the string is a valid XML; otherwise, false.</returns>
        public static bool IsValidXml(this string input)
        {
            try
            {
                var doc = new XmlDocument();
                doc.LoadXml(input);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Validates if the input is a valid Base64 string.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>True if the string is a valid Base64; otherwise, false.</returns>
        public static bool IsValidBase64(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

#if NET8_0_OR_GREATER || NET7_0_OR_GREATER || NET6_0_OR_GREATER 
            Span<byte> buffer = new byte[input.Length];
            return System.Convert.TryFromBase64String(input, buffer, out _);
#else
            input = input.Trim();
            if (input.Length % 4 != 0)
                return false;
            try
            {
                System.Convert.FromBase64String(input);
                return true;
            }
            catch
            {
                return false;
            }
#endif

        }

        /// <summary>
        /// Validates if the input is a valid IP address.
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>True if the string is a valid IP address; otherwise, false.</returns>
        public static bool IsValidIpAddress(this string input)
        {
            return IPAddress.TryParse(input, out _);
        }

        /// <summary>
        /// Validates if the input is a valid credit card number (Luhn algorithm).
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>True if the string is a valid credit card number; otherwise, false.</returns>
        public static bool IsValidCreditCard(this string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;

            var digits = Regex.Replace(input, @"[^\d]", "");
            int sum = 0;
            bool alternate = false;

            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int n = int.Parse(digits[i].ToString());

                if (alternate)
                {
                    n *= 2;
                    if (n > 9) n -= 9;
                }

                sum += n;
                alternate = !alternate;
            }

            return sum % 10 == 0;
        }

        /// <summary>
        /// Validates if the input is a valid hex color (e.g., #FFF, #FFFFFF).
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>True if the string is a valid hex color; otherwise, false.</returns>
        public static bool IsValidHexColor(this string input)
        {
            return Regex.IsMatch(input, @"^#(?:[0-9a-fA-F]{3}){1,2}$");
        }

        /// <summary>
        /// Validates if the input is a valid phone number (basic check).
        /// </summary>
        /// <param name="input">The input string to validate.</param>
        /// <returns>True if the string is a valid phone number; otherwise, false.</returns>
        public static bool IsValidPhoneNumber(this string input)
        {
            return Regex.IsMatch(input, @"^\+?\d{7,15}$");
        }

        /// <summary>
        /// Validates password based on given complexity requirements.
        /// </summary>
        /// <param name="input">The input string to validate as a password.</param>
        /// <param name="minLength">Minimum length of the password.</param>
        /// <param name="requireSpecialChar">Whether to require at least one special character.</param>
        /// <param name="requireDigit">Whether to require at least one digit.</param>
        /// <param name="requireUppercase">Whether to require at least one uppercase letter.</param>
        /// <param name="requireLowercase">Whether to require at least one lowercase letter.</param>
        /// <param name="requireUppercase">Whether to require at least one uppercase letter.</param>
        /// <param name="requireLowercase">Whether to require at least one lowercase letter.</param>
        /// <returns>True if the password meets the complexity requirements; otherwise, false.</returns>
        public static bool IsValidPassword(this string input, int minLength = 8, bool requireSpecialChar = false, bool requireDigit = false, bool requireUppercase = false, bool requireLowercase = false)
        {
            if (string.IsNullOrEmpty(input) || input.Length < minLength)
                return false;

            if (requireDigit && !input.Any(char.IsDigit)) return false;
            if (requireUppercase && !input.Any(char.IsUpper)) return false;
            if (requireLowercase && !input.Any(char.IsLower)) return false;
            if (requireSpecialChar && !input.Any(ch => !char.IsLetterOrDigit(ch))) return false;

            return true;
        }

        /// <summary>
        /// Validates if the input is a valid username with length constraints.
        /// </summary>
        /// <param name="input">The input string to validate as a username.</param>
        /// <param name="minLength">Minimum length of the username.</param>
        /// <param name="maxLength">Maximum length of the username.</param>
        /// <returns>True if the username meets the length constraints and contains only valid characters; otherwise, false.</returns>
        public static bool IsValidUsername(this string input, int minLength = 3, int maxLength = 20)
        {
            return Regex.IsMatch(input, $"^[a-zA-Z0-9_.-]{{{minLength},{maxLength}}}$");
        }
    }
}