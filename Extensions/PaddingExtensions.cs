namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods for string padding.
    /// </summary>
    public static class PaddingExtensions
    {
        /// <summary>
        /// Pads the string on the left with the specified character until it reaches the total width.
        /// </summary>
        /// <param name="input">The input string to pad.</param>
        /// <param name="totalWidth">The total width of the resulting string after padding.</param>
        /// <param name="paddingChar">The character to use for padding.</param>
        /// <returns>A new string padded on the left, or empty string if input is null.</returns>
        public static string PadLeftWith(this string input, int totalWidth, char paddingChar) =>
            input?.PadLeft(totalWidth, paddingChar) ?? string.Empty;

        /// <summary>
        /// Pads the string on the right with the specified character until it reaches the total width.
        /// </summary>
        /// <param name="input">The input string to pad.</param>
        /// <param name="totalWidth">The total width of the resulting string after padding.</param>
        /// <param name="paddingChar">The character to use for padding.</param>
        /// <returns>A new string padded on the right, or empty string if input is null.</returns>
        public static string PadRightWith(this string input, int totalWidth, char paddingChar) =>
            input?.PadRight(totalWidth, paddingChar) ?? string.Empty;

        /// <summary>
        /// Pads the string on both sides with the specified character until it reaches the total width.
        /// </summary>
        /// <param name="input">The input string to pad.</param>
        /// <param name="totalWidth">The total width of the resulting string after padding.</param>
        /// <param name="paddingChar">The character to use for padding.</param>
        /// <returns>A new string padded on both sides, or empty string if input is null.</returns>
        public static string PadBothWith(this string input, int totalWidth, char paddingChar)
        {
            if (string.IsNullOrEmpty(input))
                return string.Empty;

            int spaces = totalWidth - input.Length;
            if (spaces <= 0)
                return input;

            int padLeft = spaces / 2;
            int padRight = spaces - padLeft;

            return new string(paddingChar, padLeft) + input + new string(paddingChar, padRight);
        }

        /// <summary>
        /// Pads the string on the left with zeros until it reaches the total width.
        /// </summary>
        /// <param name="input">The input string to pad.</param>
        /// <param name="totalWidth">The total width after padding.</param>
        /// <returns>A new string padded on the left with zeros.</returns>
        public static string PadLeftWithZeros(this string input, int totalWidth) =>
            input?.PadLeft(totalWidth, '0') ?? string.Empty;

        /// <summary>
        /// Pads the string on the right with zeros until it reaches the total width.
        /// </summary>
        /// <param name="input">The input string to pad.</param>
        /// <param name="totalWidth">The total width after padding.</param>
        /// <returns>A new string padded on the right with zeros.</returns>
        public static string PadRightWithZeros(this string input, int totalWidth) =>
            input?.PadRight(totalWidth, '0') ?? string.Empty;

        /// <summary>
        /// Pads the string on both sides with zeros until it reaches the total width.
        /// </summary>
        /// <param name="input">The input string to pad.</param>
        /// <param name="totalWidth">The total width after padding.</param>
        /// <returns>A new string padded on both sides with zeros.</returns>
        public static string PadBothWithZeros(this string input, int totalWidth) =>
            PadBothWith(input, totalWidth, '0');

        /// <summary>
        /// Pads the string on the left with spaces until it reaches the total width.
        /// </summary>
        /// <param name="input">The input string to pad.</param>
        /// <param name="totalWidth">The total width after padding.</param>
        /// <returns>A new string padded on the left with spaces.</returns>
        public static string PadLeftWithSpaces(this string input, int totalWidth) =>
            input?.PadLeft(totalWidth, ' ') ?? string.Empty;

        /// <summary>
        /// Pads the string on the right with spaces until it reaches the total width.
        /// </summary>
        /// <param name="input">The input string to pad.</param>
        /// <param name="totalWidth">The total width after padding.</param>
        /// <returns>A new string padded on the right with spaces.</returns>
        public static string PadRightWithSpaces(this string input, int totalWidth) =>
            input?.PadRight(totalWidth, ' ') ?? string.Empty;

        /// <summary>
        /// Pads the string on both sides with spaces until it reaches the total width.
        /// </summary>
        /// <param name="input">The input string to pad.</param>
        /// <param name="totalWidth">The total width after padding.</param>
        /// <returns>A new string padded on both sides with spaces.</returns>
        public static string PadBothWithSpaces(this string input, int totalWidth) =>
            PadBothWith(input, totalWidth, ' ');
    }
}