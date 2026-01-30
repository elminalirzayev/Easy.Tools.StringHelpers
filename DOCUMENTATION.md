# Easy.Tools.StringHelpers Documentation

This document provides in-depth documentation for all available string extension methods within the `Easy.Tools.StringHelpers` package.

---

## Table of Contents

1. [ValidationExtensions](#1-validationextensions)
2. [TruncateExtensions](#2-truncateextensions)
3. [ManipulationExtensions](#3-manipulationextensions)
4. [MaskingExtensions](#4-maskingextensions)
5. [SanitizeExtensions](#5-sanitizeextensions)
6. [TransformationExtensions](#6-transformationextensions)
7. [SearchExtensions](#7-searchextensions)
8. [FormatExtensions](#8-formatextensions)
9. [GenerationExtensions](#9-generationextensions)
10. [CasingExtensions](#10-casingextensions)
11. [LengthExtensions](#11-lengthextensions)
12. [RegexExtensions](#12-regexextensions)
13. [ConversionExtensions](#13-conversionextensions)
14. [PaddingExtensions](#14-paddingextensions)
15. [DateParsingExtensions](#15-dateparsingextensions)

---

## 1. ValidationExtensions

Provides robust validation methods. Most methods utilize optimized algorithms (like Luhn for credit cards) or compiled Regex with timeouts to ensure security.

- `IsValidEmail(string input)`: Checks if the string is a valid email format.
- `IsValidUrl(string input)`: Checks if the string is a valid absolute URL (HTTP/HTTPS).
- `IsValidCreditCard(string input)`: Validates credit card numbers using the **Luhn Algorithm** (Zero Allocation).
- `IsPalindrome(string input)`: Checks if the string is a palindrome (ignores case/symbols).
- `IsValidJson(string input)`: Checks if the string is valid JSON structure.
- `IsValidXml(string input)`: Checks if the string is valid XML.
- `IsValidBase64(string input)`: Checks if the string is a valid Base64 encoded string.
- `IsValidIpAddress(string input)`: Validates IPv4 and IPv6 addresses.
- `IsValidHexColor(string input)`: Validates Hex color codes (e.g., #FFF, #FFFFFF).
- `IsValidPhoneNumber(string input)`: Basic international phone number validation.
- `IsValidGuid(string input)`: Checks if string is a GUID.
- `IsValidPassword(string input, int minLength, bool requireSpecialChar, ...)`: Validates password complexity.
- `IsValidUsername(string input)`: Validates username (alphanumeric, dots, underscores).
- `IsValidDate(string input)`: Checks if the string is a valid date format.

---

## 2. TruncateExtensions

Efficient string truncation methods.

- `Truncate(string input, int maxLength, bool addEllipsis = false)`: Truncates the string. If `addEllipsis` is true, adds "..." within the limit.
- `TruncateFromLeft(string input, int maxLength)`: Truncates the string from the LEFT side (keeps the end of the string).

---

## 3. ManipulationExtensions

General purpose string manipulation methods designed for performance.

- `RemoveWhitespace(string input)`: Removes **all** whitespace characters using a fast character loop (faster than Regex).
- `Repeat(string input, int count)`: Repeats the string `count` times.
- `SplitLines(string input)`: Splits the string into an array of lines, normalizing `\r\n`, `\r`, and `\n`.
- `SplitByLength(string input, int length)`: Splits the string into chunks of the specified length.
- `SplitByLengthWithSeparator(string input, int length, string separator)`: Splits the string by length and joins the parts with the specified separator.
- `SplitByLengthWithSeparatorAndTrim(string input, int length, string separator)`: Splits by length, trims each part, and joins with the separator.
- `SplitByLengthWithSeparatorAndTrimAndRemoveEmpty(string input, int length, string separator)`: Splits by length, trims parts, removes empty ones, and joins with the separator.
- `NormalizeSpaces(string input)`: Replaces multiple consecutive spaces with a single space (e.g., "a   b" -> "a b").
- `NormalizeLineEndings(string input, string newline)`: Converts all line endings to the specified format (default `\n`).
- `TrimToEmpty(string input)`: Trims whitespace. Returns `string.Empty` if input is null.
- `TrimToNull(string input)`: Trims whitespace. Returns `null` if the result is empty or whitespace.
- `TrimStartToEmpty(string input)`: Trims start. Returns `string.Empty` if input is null.
- `TrimStartToNull(string input)`: Trims start. Returns `null` if the result is empty.
- `TrimEndToEmpty(string input)`: Trims end. Returns `string.Empty` if input is null.
- `TrimEndToNull(string input)`: Trims end. Returns `null` if the result is empty.
- `Truncate(string input, int maxLength, string suffix)`: Truncates the string to a max length and appends a suffix (default "...").
- `Reverse(string input)`: Reverses the order of characters in the string.

---

## 4. MaskingExtensions

Methods for masking sensitive PII (Personally Identifiable Information).

- `MaskEmail(string email)`: Masks email addresses (e.g., `j*****@example.com`).
- `MaskLeft(string input, int visibleCount, char maskChar)`: Masks characters from the left.
- `MaskRight(string input, int visibleCount, char maskChar)`: Masks characters from the right.

---

## 5. SanitizeExtensions

High-performance methods to remove unwanted characters. **Note:** Uses character loops instead of Regex where possible for 10x performance.

- `StripHtmlTags(string input)`: Removes HTML tags safely.
- `RemoveSpecialCharacters(string input)`: Keeps only letters and digits.
- `RemoveDigits(string input)`: Removes all numeric digits.
- `RemoveLetters(string input)`: Removes all letters.
- `RemoveNonAscii(string input)`: Removes characters outside the ASCII range.
- `RemovePunctuation(string input)`: Removes punctuation marks.

---

## 6. TransformationExtensions

- `GenerateSlug(string input)`: Converts string to URL-friendly slug (Handles Turkish chars: ı->i, ğ->g).
- `ToInitials(string input)`: Extracts initials from a name (e.g., "John Doe" -> "JD").
- `Reverse(string input)`: Reverses the string (Span-optimized).

---

## 7. SearchExtensions

- `ContainsIgnoreCase(string source, string toCheck)`
- `ReplaceIgnoreCase(string source, string oldValue, string newValue)`
- `CountOccurrences(string source, char c)`
- `IsNumeric(string source)`: Checks if the string contains only digits.
- `ExtractDigits(string source)`: Returns a new string containing only the digits found in the input.
- `ContainsAny(string input, params string[] values)`
- `ContainsAll(string input, params string[] values)`
- `EqualsIgnoreCase(string input, string other)`
- `StartsWithIgnoreCase(string input, string value)`
- `EndsWithIgnoreCase(string input, string value)`

---

## 8. FormatExtensions

- `ToSnakeCase(string input)`: "Hello World" -> "hello_world"
- `ToKebabCase(string input)`: "Hello World" -> "hello-world"
- `SplitCamelCase(string input)`: "CamelCase" -> "Camel Case"
- `RemoveDiacritics(string input)`: Removes accents (e.g., 'é' -> 'e').

---

## 9. GenerationExtensions

Uses `RandomNumberGenerator` (CSPRNG) for security.

- `RandomString(int length)`: Generates alphanumeric random string.
- `RandomPassword(int length)`: Generates secure password with special characters.

---

## 10. CasingExtensions

- `ToTitleCase(string input, CultureInfo culture)`
- `ToInvariantLower(string input)`
- `ToInvariantUpper(string input)`

---

## 11. LengthExtensions

- `LongerThan(string input, int length)`
- `ShorterThan(string input, int length)`
- `IsLengthEqual(string input, int length)`
- `IsLengthBetween(string input, int min, int max)`

---

## 12. RegexExtensions

Includes timeout protection against ReDoS.

- `MatchesRegex(string input, string pattern)`
- `ExtractMatches(string input, string pattern)`

---

## 13. ConversionExtensions

Safe type conversion methods. Returns `null` instead of throwing exceptions on failure.

- `To<T>(string input)`: Generic converter for Structs, Enums, and primitives.
- `ToIntOrNull(string input)`: Converts to `int?`.
- `ToBooleanOrNull(string input)`: Converts to `bool?`.
- `ToDateTimeOrNull(string input)`: Converts to `DateTime?`.
- `ToDoubleOrNull(string input)`: Converts to `double?` (Invariant Culture).
- `ToDecimalOrNull(string input)`: Converts to `decimal?` (Invariant Culture).
- `ToFloatOrNull(string input)`: Converts to `float?` (Invariant Culture).
- `ToGuidOrNull(string input)`: Converts to `Guid?`.
- `ToByteOrNull(string input)`: Converts to `byte?`.
- `ToShortOrNull(string input)`: Converts to `short?`.
- `ToLongOrNull(string input)`: Converts to `long?`.
- `ToSByteOrNull(string input)`: Converts to `sbyte?`.
- `ToUIntOrNull(string input)`: Converts to `uint?`.
- `ToUShortOrNull(string input)`: Converts to `ushort?`.
- `ToULongOrNull(string input)`: Converts to `ulong?`.
- `ToCharOrNull(string input)`: Converts to `char?` (Returns null if length != 1).

---

## 14. PaddingExtensions

- `PadLeftWith(string input, int width, char paddingChar)`
- `PadRightWith(string input, int width, char paddingChar)`
- `PadBothWith(string input, int width, char paddingChar)`: Centers the string.
- `PadLeftWithZeros(string input, int width)`
- `PadRightWithZeros(string input, int width)`
- `PadBothWithZeros(string input, int width)`
- `PadLeftWithSpaces(string input, int width)`
- `PadRightWithSpaces(string input, int width)`
- `PadBothWithSpaces(string input, int width)`

---

## 15. DateParsingExtensions

- `IsValidDate(string input)`
- `IsValidDateExact(string input, string format)`