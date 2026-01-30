using System;

namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods for truncating strings efficiently.
    /// </summary>
    public static class TruncateExtensions
    {
        /// <summary>
        /// Truncates the string to the specified maxLength.
        /// If addEllipsis is true, adds "..." to the END of the string.
        /// </summary>
        /// <param name="input">The input string to truncate.</param>
        /// <param name="maxLength">The maximum length of the resulting string.</param>
        /// <param name="addEllipsis">If true, adds "..." to the end if truncation occurs.</param>
        /// <returns>A truncated string, or string.Empty if input is null.</returns>
        public static string Truncate(this string input, int maxLength, bool addEllipsis = false)
        {
            if (string.IsNullOrEmpty(input) || maxLength <= 0) return string.Empty;
            if (input.Length <= maxLength) return input;

            if (addEllipsis)
            {
                if (maxLength <= 3) return input.Substring(0, maxLength);
                int lengthToKeep = maxLength - 3;

#if NET6_0_OR_GREATER
                // Modern .NET Zero Allocation approach
                return string.Create(maxLength, (input, lengthToKeep), (span, state) =>
                {
                    var (str, len) = state;
                    str.AsSpan(0, len).CopyTo(span);
                    span[len] = '.';
                    span[len + 1] = '.';
                    span[len + 2] = '.';
                });
#else
                // Legacy Fallback
                return input.Substring(0, lengthToKeep) + "...";
#endif
            }

            return input.Substring(0, maxLength);
        }

        /// <summary>
        /// Truncates the string from the LEFT side (keeps the end of the string).
        /// Automatically adds "..." to the beginning if truncation occurs.
        /// Example: "Hello World", 6 -> "...rld"
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="maxLength">The maximum total length of the result (including ellipsis).</param>
        /// <returns>The string truncated from the left.</returns>
        public static string TruncateFromLeft(this string input, int maxLength)
        {
            if (string.IsNullOrEmpty(input) || maxLength <= 0) return string.Empty;
            if (input.Length <= maxLength) return input;

            // If length is too small to fit ellipsis, just return the end of the string
            if (maxLength <= 3) return input.Substring(input.Length - maxLength);

            int lengthToKeep = maxLength - 3;
            int startIndex = input.Length - lengthToKeep;

#if NET6_0_OR_GREATER
            // Modern .NET Zero Allocation approach
            return string.Create(maxLength, (input, startIndex), (span, state) =>
            {
                var (str, start) = state;
                // Add ellipsis at the start
                span[0] = '.';
                span[1] = '.';
                span[2] = '.';
                // Copy the rest of the string
                str.AsSpan(start).CopyTo(span.Slice(3));
            });
#else
            // Legacy Fallback
            return "..." + input.Substring(startIndex);
#endif
        }
    }
}