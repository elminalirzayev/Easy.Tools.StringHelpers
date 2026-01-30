using System;
using System.ComponentModel;
using System.Globalization;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods for safe type conversions.
    /// </summary>
    public static class ConversionExtensions
    {
        /// <summary>
        /// Converts the string to an integer. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The integer value or null.</returns>
        public static int? ToIntOrNull(this string input) =>
            int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a boolean. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The boolean value or null.</returns>
        public static bool? ToBooleanOrNull(this string input) =>
            bool.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a DateTime. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <returns>The DateTime value or null.</returns>
        public static DateTime? ToDateTimeOrNull(this string input) =>
            DateTime.TryParse(input, CultureInfo.InvariantCulture, DateTimeStyles.None, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a double using invariant culture. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The double value or null.</returns>
        public static double? ToDoubleOrNull(this string input) =>
            double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a GUID. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The Guid value or null.</returns>
        public static Guid? ToGuidOrNull(this string input) =>
            Guid.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a decimal using invariant culture. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The decimal value or null.</returns>
        public static decimal? ToDecimalOrNull(this string input) =>
            decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a byte. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The byte value or null.</returns>
        public static byte? ToByteOrNull(this string input) =>
            byte.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a short. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The short value or null.</returns>
        public static short? ToShortOrNull(this string input) =>
            short.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a long. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The long value or null.</returns>
        public static long? ToLongOrNull(this string input) =>
            long.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a float using invariant culture. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The float value or null.</returns>
        public static float? ToFloatOrNull(this string input) =>
            float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out var result) ? result : null;

        /// <summary>
        /// Converts the string to an sbyte. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The sbyte value or null.</returns>
        public static sbyte? ToSByteOrNull(this string input) =>
            sbyte.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to an unsigned int. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The uint value or null.</returns>
        public static uint? ToUIntOrNull(this string input) =>
            uint.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to an unsigned short. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The ushort value or null.</returns>
        public static ushort? ToUShortOrNull(this string input) =>
            ushort.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to an unsigned long. Returns null if conversion fails.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The ulong value or null.</returns>
        public static ulong? ToULongOrNull(this string input) =>
            ulong.TryParse(input, out var result) ? result : null;

        /// <summary>
        /// Converts the string to a char. Returns null if conversion fails or input length is not 1.
        /// </summary>
        /// <param name="input">The input string to convert.</param>
        /// <returns>The char value or null.</returns>
        public static char? ToCharOrNull(this string input) =>
            !string.IsNullOrEmpty(input) && input.Length == 1 ? input[0] : (char?)null;

        /// <summary>
        /// Converts the string to a generic type T. Returns null (or default) if conversion fails.
        /// Supports primitives, Enums, and types with a TypeConverter.
        /// </summary>
        /// <typeparam name="T">The target struct type.</typeparam>
        /// <param name="input">The input string.</param>
        /// <returns>The converted value or null.</returns>
        public static T? To<T>(this string input) where T : struct
        {
            if (string.IsNullOrWhiteSpace(input)) return null;

            Type type = typeof(T);

            // Optimization for common primitive types to avoid TypeDescriptor overhead
            if (type == typeof(int) && int.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out var i)) return (T)(object)i;
            if (type == typeof(long) && long.TryParse(input, NumberStyles.Integer, CultureInfo.InvariantCulture, out var l)) return (T)(object)l;
            if (type == typeof(double) && double.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out var d)) return (T)(object)d;
            if (type == typeof(decimal) && decimal.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out var dec)) return (T)(object)dec;
            if (type == typeof(bool) && bool.TryParse(input, out var b)) return (T)(object)b;
            if (type == typeof(Guid) && Guid.TryParse(input, out var g)) return (T)(object)g;

            // Handle Enums
            if (type.IsEnum)
            {
                if (Enum.TryParse<T>(input, true, out var enumResult))
                    return enumResult;
                return null;
            }

            try
            {
                var converter = TypeDescriptor.GetConverter(type);
                if (converter != null && converter.CanConvertFrom(typeof(string)))
                {
                    return (T?)converter.ConvertFromString(input);
                }
            }
            catch
            {
                // Swallow exception on purpose for "safe" conversion
            }
            return null;
        }
    }
}