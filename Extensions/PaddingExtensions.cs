using System;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods for string padding operations.
    /// </summary>
    public static class PaddingExtensions
    {
        /// <summary>
        /// Pads the string on the left with the specified character until it reaches the total width.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="totalWidth">Total width required.</param>
        /// <param name="paddingChar">Char to use for padding.</param>
        /// <returns>Padded string.</returns>
        public static string PadLeftWith(this string input, int totalWidth, char paddingChar) =>
            input?.PadLeft(totalWidth, paddingChar) ?? string.Empty;

        /// <summary>
        /// Pads the string on the right with the specified character until it reaches the total width.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="totalWidth">Total width required.</param>
        /// <param name="paddingChar">Char to use for padding.</param>
        /// <returns>Padded string.</returns>
        public static string PadRightWith(this string input, int totalWidth, char paddingChar) =>
            input?.PadRight(totalWidth, paddingChar) ?? string.Empty;

        /// <summary>
        /// Pads the string on both sides (center alignment) with the specified character.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="totalWidth">Total width required.</param>
        /// <param name="paddingChar">Char to use for padding.</param>
        /// <returns>Centered and padded string.</returns>
        public static string PadBothWith(this string input, int totalWidth, char paddingChar)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;
            if (input.Length >= totalWidth) return input;

            int padTotal = totalWidth - input.Length;
            int padLeft = padTotal / 2;
            int padRight = padTotal - padLeft;

#if NET6_0_OR_GREATER
            // Zero-allocation implementation for modern .NET
            return string.Create(totalWidth, (input, paddingChar, padLeft, padRight), (span, state) =>
            {
                var (str, pChar, left, right) = state;
                span.Slice(0, left).Fill(pChar);
                str.AsSpan().CopyTo(span.Slice(left));
                span.Slice(left + str.Length).Fill(pChar);
            });
#else
            // Fallback for legacy .NET
            var result = new char[totalWidth];
            for (int i = 0; i < padLeft; i++) result[i] = paddingChar;
            input.CopyTo(0, result, padLeft, input.Length);
            for (int i = padLeft + input.Length; i < totalWidth; i++) result[i] = paddingChar;
            return new string(result);
#endif
        }

        // --- Convenience Methods ---

        /// <summary>Pads left with zeros.</summary>
        /// <param name="input">Input string.</param>
        /// <param name="totalWidth">Target width.</param>
        /// <returns>Padded string.</returns>
        public static string PadLeftWithZeros(this string input, int totalWidth) => PadLeftWith(input, totalWidth, '0');

        /// <summary>Pads right with zeros.</summary>
        /// <param name="input">Input string.</param>
        /// <param name="totalWidth">Target width.</param>
        /// <returns>Padded string.</returns>
        public static string PadRightWithZeros(this string input, int totalWidth) => PadRightWith(input, totalWidth, '0');

        /// <summary>Pads both sides with zeros.</summary>
        /// <param name="input">Input string.</param>
        /// <param name="totalWidth">Target width.</param>
        /// <returns>Padded string.</returns>
        public static string PadBothWithZeros(this string input, int totalWidth) => PadBothWith(input, totalWidth, '0');

        /// <summary>Pads left with spaces.</summary>
        /// <param name="input">Input string.</param>
        /// <param name="totalWidth">Target width.</param>
        /// <returns>Padded string.</returns>
        public static string PadLeftWithSpaces(this string input, int totalWidth) => PadLeftWith(input, totalWidth, ' ');

        /// <summary>Pads right with spaces.</summary>
        /// <param name="input">Input string.</param>
        /// <param name="totalWidth">Target width.</param>
        /// <returns>Padded string.</returns>
        public static string PadRightWithSpaces(this string input, int totalWidth) => PadRightWith(input, totalWidth, ' ');

        /// <summary>Pads both sides with spaces.</summary>
        /// <param name="input">Input string.</param>
        /// <param name="totalWidth">Target width.</param>
        /// <returns>Padded string.</returns>
        public static string PadBothWithSpaces(this string input, int totalWidth) => PadBothWith(input, totalWidth, ' ');
    }
}