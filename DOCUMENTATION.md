# Easy.Tools.StringHelpers Documentation

This document provides in-depth documentation for all available string extension methods within the `Easy.Tools.StringHelpers` package.

---

## Table of Contents

1. [SearchExtensions](#1-searchextensions)
2. [FormatExtensions](#2-formatextensions)
3. [ManipulationExtensions](#3-manipulationextensions)
4. [ValidationExtensions](#4-validationextensions)
5. [GenerationExtensions](#5-generationextensions)
6. [SanitizeExtensions](#6-sanitizeextensions)
7. [CasingExtensions](#7-casingextensions)
8. [LengthExtensions](#8-lengthextensions)
9. [RegexExtensions](#9-regexextensions)
10.[DateParsingExtensions](#10-dateparsingextensions)
11.[ConversionExtensions](#11-conversionextensions)
12.[PaddingExtensions](#12-paddingextensions)
13.[TruncateExtensions](#13-rruncateextensions)

---

## 1. SearchExtensions

- `ContainsIgnoreCase(string input, string toCheck)`
- `ReplaceIgnoreCase(string input, string oldValue, string newValue)`
- `CountOccurrences(string input, char c)`
- `IsNumeric(string source)`
- `ExtractDigits(string source)`
- `ContainsAny(string input, params string[] values)`
- `ContainsAll(string input, params string[] values)`
- `EqualsIgnoreCase(string input, string other)`
- `StartsWithIgnoreCase(string input, string value)`
- `EndsWithIgnoreCase( string input, string value)`

---

## 2. FormatExtensions

- `ToSnakeCase(string input)`
- `ToKebabCase(string input)`
- `SplitCamelCase(string input)`
- `RemoveDiacritics(string input)`

---

## 3. ManipulationExtensions

- `RemoveWhitespace(string input)`
- `Repeat(string input, int count)`
- `SplitLines(string input, int length)`
- `SplitByLength(string input, int length)`
- `SplitByLengthWithSeparator(string input, int length, string separator)`
- `SplitByLengthWithSeparatorAndTrim(string input, int length, string separator)`
- `SplitByLengthWithSeparatorAndTrimAndRemoveEmpty(string input, int length, string separator)`
- `TrimWhitespace(string input)`
- `TrimToEmpty(string input)`
- `TrimToNull(string input)`
- `TrimStartToEmpty(string input)`
- `TrimStartToNull(string input)`
- `TrimEndToEmpty(string input)`
- `TrimEndToNull(string input)`
- `NormalizeLineEndings(string input, string newline = "\n")`
- `NormalizeSpaces(string input)`

---

## 4. ValidationExtensions

- `IsPalindrome(string input)`
- `IsValidEmail(string input)`
- `IsValidUrl(string input)`
- `IsValidPhoneNumber(string input)`
- `IsValidGuid(string input)`
- `IsValidDate(string input)`
- `IsValidJson(string input)`
- `IsValidXml(string input)`
- `IsValidBase64(string input)`
- `IsValidIpAddress(string input)`
- `IsValidCreditCard(string input)`
- `IsValidHexColor(string input)`
- `IsValidPassword(string input, int minLength = 8, bool requireSpecialChar = false, bool requireDigit = false, bool requireUppercase = false, bool requireLowercase = false)`
- `IsValidUsername(string input, int minLength = 3, int maxLength = 20)`

---

## 5. GenerationExtensions

- `GenerateRandomString(int length)`
- `GenerateSlug(string input)`
- `ToInitials(string input)`

---

## 6. SanitizeExtensions

- `StripHtmlTags(string input)`
- `RemoveSpecialCharacters(string input)`
- `RemoveDigits(string input)`
- `RemoveLetters(string input)`
- `RemoveNonAscii(string input)`
- `RemovePunctuation(string input)`

---

## 7. CasingExtensions

- `ToTitleCase(string input)`
- `ToInvariantLower(string input)`
- `ToInvariantUpper(string input)`

---

## 8. LengthExtensions

- `IsLongerThan(string input, int length)`
- `IsShorterThan(string input, int length)`

---

## 9. RegexExtensions

- `MatchRegex(string input, string pattern)`
- `ExtractMatches(string input, string pattern)`

---

## 10. DateParsingExtensions

- `ContainsDate(string input)`

---

## 11. ConversionExtensions

- `ToIntOrNull(string input)`
- `ToBooleanOrNull(string input)`
- `ToDoubleOrNull(string input)`
- `ToDateTimeOrNull(string input)`
- `ToGuidOrNull(string input)`
- `ToDecimalOrNull(string input)`
- `ToByteOrNull(string input)`
- `ToShortOrNull(string input)`
- `ToLongOrNull(string input)`
- `ToCharOrNull(string input)`
- `ToFloatOrNull(string input)`
- `ToSByteOrNull(string input)`
- `ToUIntOrNull(string input)`
- `ToUShortOrNull(string input)`
- `ToULongOrNull(string input)`
- `ToUByteOrNull(string input)`

---

## 12. PaddingExtensions

- `PadLeftWith(string input, int totalWidth, char paddingChar)`
- `PadRightWith(string input, int totalWidth, char paddingChar)`
- `PadBothWith(string input, int totalWidth, char paddingChar)`
- `PadLeftWithZeros(string input, int totalWidth)`
- `PadRightWithZeros(string input, int totalWidth)`
- `PadBothWithZeros(string input, int totalWidth)`
- `PadLeftWithSpaces(string input, int totalWidth)`
- `PadRightWithSpaces(string input, int totalWidth)`
- `PadBothWithSpaces(string input, int totalWidth)`

---

## 13. TruncateExtensions

- `Truncate(string input, int maxLength, bool addEllipsis = false)`

## Usage Examples

```csharp
string test = "helloWorldExample";
string snake = test.ToSnakeCase(); // hello_world_example

bool isValid = "123456".IsNumeric(); // true

string clean = "<b>html</b>".StripHtmlTags(); // html
```

---

## Notes

All methods are implemented as C# extension methods and must be used with:

```csharp
using Easy.Tools.StringHelpers.Extensions;
```

---

## License

MIT