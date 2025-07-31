namespace Easy.Tools.StringHelpers.Extensions
{
    /// <summary>
    /// Extension methods for truncating strings.
    /// </summary>
    public static class TruncateExtensions
    {
        /// <summary>
        /// Truncates the string to the specified maxLength. Adds ellipsis if needed.
        /// </summary>
        /// <param name="input">The input string to truncate.</param>
        /// <param name="maxLength">The maximum length of the resulting string.</param>
        /// <param name="addEllipsis">If true, adds "..." to the end if truncation occurs.</param>
        /// <returns>A truncated string, or an empty string if input is null or maxLength is less than or equal to zero.</returns>
        /// This method checks if the input string is null or empty, and if the maxLength is less than or equal to zero.
        /// If the input string is longer than maxLength, it truncates the string to maxLength and optionally adds an ellipsis ("...") at the end.
        /// If the input string is shorter than or equal to maxLength, it returns the original string.
        public static string Truncate(this string input, int maxLength, bool addEllipsis = false)
        {
            if (string.IsNullOrEmpty(input) || maxLength <= 0)
                return string.Empty;

            if (input.Length <= maxLength)
                return input;

            return addEllipsis && maxLength > 3
                ? input.Substring(0, maxLength - 3) + "..."
                : input.Substring(0, maxLength);
        }
    }
}
