using System.Globalization;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods for type conversions.
    /// </summary>
    public static class ConversionExtensions
    {

        /// <summary>
        /// Converts the string to an integer. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>An integer if conversion is successful; otherwise, null.</returns>
        public static int? ToIntOrNull(this string input) =>
            int.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a boolean. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>A boolean if conversion is successful; otherwise, null.</returns>
        public static bool? ToBooleanOrNull(this string input) =>
            bool.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a DateTime. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>A DateTime if conversion is successful; otherwise, null.</returns>
        public static DateTime? ToDateTimeOrNull(this string input) =>
            DateTime.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a double using invariant culture. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>A double if conversion is successful; otherwise, null.</returns>
        public static double? ToDoubleOrNull(this string input) =>
            double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a GUID. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>A Guid if conversion is successful; otherwise, null.</returns>
        public static Guid? ToGuidOrNull(this string input) =>
            Guid.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a decimal using invariant culture. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>A decimal if conversion is successful; otherwise, null.</returns>
        public static decimal? ToDecimalOrNull(this string input) =>
            decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a byte. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>A byte if conversion is successful; otherwise, null.</returns>
        public static byte? ToByteOrNull(this string input) =>
            byte.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a short. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>A short if conversion is successful; otherwise, null.</returns>
        public static short? ToShortOrNull(this string input) =>
            short.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a long. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>A long if conversion is successful; otherwise, null.</returns>
        public static long? ToLongOrNull(this string input) =>
            long.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a float using invariant culture. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>A float if conversion is successful; otherwise, null.</returns>
        public static float? ToFloatOrNull(this string input) =>
            float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out var result) ? result : null;

        /// <summary>
        /// Converts the string to an sbyte. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>An sbyte if conversion is successful; otherwise, null.</returns>
        public static sbyte? ToSByteOrNull(this string input) =>
            sbyte.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to an unsigned int. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>An unsigned int if conversion is successful; otherwise, null.</returns>
        public static uint? ToUIntOrNull(this string input) =>
            uint.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to an unsigned short. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>An unsigned short if conversion is successful; otherwise, null.</returns>
        public static ushort? ToUShortOrNull(this string input) =>
            ushort.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to an unsigned long. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>An unsigned long if conversion is successful; otherwise, null.</returns>
        public static ulong? ToULongOrNull(this string input) =>
            ulong.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a char. Returns null if conversion fails or input length is not 1.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>A char if conversion is successful; otherwise, null.</returns>
        public static char? ToCharOrNull(this string input) =>
            !string.IsNullOrEmpty(input) && input.Length == 1 ? input[0] : (char?)null;
    }
}


