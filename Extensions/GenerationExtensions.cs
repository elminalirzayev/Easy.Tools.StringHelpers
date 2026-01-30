using System;
using System.Security.Cryptography;
using System.Text;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods for secure random string and password generation.
    /// </summary>
    public static class GenerationExtensions
    {
        private const string AlphanumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        private const string SpecialChars = "!@#$%^&*()_-+=<>?";

        /// <summary>
        /// Generates a random alphanumeric string of the specified length using a cryptographically secure generator.
        /// </summary>
        /// <param name="length">The length of the string to generate.</param>
        /// <returns>A random alphanumeric string.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if length is less than or equal to zero.</exception>
        public static string RandomString(int length)
        {
            if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));
            return GenerateRandomString(length, AlphanumericChars);
        }

        /// <summary>
        /// Generates a random string containing special characters, suitable for secure passwords.
        /// </summary>
        /// <param name="length">The length of the string.</param>
        /// <returns>A random string with special characters.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if length is less than or equal to zero.</exception>
        public static string RandomPassword(int length)
        {
            if (length <= 0) throw new ArgumentOutOfRangeException(nameof(length));
            return GenerateRandomString(length, AlphanumericChars + SpecialChars);
        }

        private static string GenerateRandomString(int length, string charSet)
        {
            if (length <= 0) return string.Empty;

            var result = new char[length];
            byte[] randomBytes = new byte[length];

            // Use Cryptographic RNG for security
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            for (int i = 0; i < length; i++)
            {
                // Modulo operation to map byte to charSet index
                result[i] = charSet[randomBytes[i] % charSet.Length];
            }

            return new string(result);
        }
    }
}