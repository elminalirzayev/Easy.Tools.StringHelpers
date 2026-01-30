[![Build & Test](https://github.com/elminalirzayev/Easy.Tools.StringHelpers/actions/workflows/build.yml/badge.svg)](https://github.com/elminalirzayev/Easy.Tools.StringHelpers/actions/workflows/build.yml)
[![Build & Release](https://github.com/elminalirzayev/Easy.Tools.StringHelpers/actions/workflows/release.yml/badge.svg)](https://github.com/elminalirzayev/Easy.Tools.StringHelpers/actions/workflows/release.yml)
[![Build & Nuget Publish](https://github.com/elminalirzayev/Easy.Tools.StringHelpers/actions/workflows/nuget.yml/badge.svg)](https://github.com/elminalirzayev/Easy.Tools.StringHelpers/actions/workflows/nuget.yml)
[![Release](https://img.shields.io/github/v/release/elminalirzayev/Easy.Tools.StringHelpers)](https://github.com/elminalirzayev/Easy.Tools.StringHelpers/releases)
[![License](https://img.shields.io/github/license/elminalirzayev/Easy.Tools.StringHelpers)](https://github.com/elminalirzayev/Easy.Tools.StringHelpers/blob/master/LICENSE.txt)
[![NuGet](https://img.shields.io/nuget/v/Easy.Tools.StringHelpers.svg)](https://www.nuget.org/packages/Easy.Tools.StringHelpers)

# Easy.Tools.StringHelpers

**Easy.Tools.StringHelpers** is a high-performance, secure, and enterprise-ready .NET library providing a rich set of string extension methods. It is re-engineered with **Zero-Allocation** techniques for modern .NET, **ReDoS protection** for Regex operations, and strictly typed validation helpers.


## Key Features

- ** High Performance & Zero-Allocation:** Utilizes `Span<T>`, `string.Create`, and `ValueTuple` on modern frameworks (.NET 6+) to minimize memory pressure.
- ** Security First:** - All internal Regex operations use **Timeouts** to prevent **ReDoS** (Regular Expression Denial of Service).
  - Random string/password generation uses **CSPRNG** (Cryptographically Secure Pseudo-Random Number Generator).
- ** Enterprise Validation:** Built-in validators for Credit Cards (Luhn Algorithm), JSON, XML, URLs, Emails (RFC-compliant regex), and more.
- ** Multi-Framework Support:** Runs everywhere. Supports `.NET 10`, `.NET 9`, `.NET 8`, `.NET 6`, `.NET Standard 2.0/2.1`, and `.NET Framework 4.7.2+`.

## Installation

Install via NuGet Package Manager:
```powershell
Install-Package Easy.Tools.StringHelpers
```

Or via .NET CLI:

```powershell
dotnet add package Easy.Tools.StringHelpers
```


## Usage Examples

### 1. Secure Validation

Validate inputs without throwing unnecessary exceptions.

```csharp
using Easy.Tools.StringHelpers.Extensions;

// Email & Password Validation
if (userInput.IsValidEmail() && password.IsValidPassword(minLength: 10, requireSpecialChar: true))
{
    // Proceed safely...
}

// Credit Card Validation (Luhn Algorithm - Zero Allocation)
if (creditCardString.IsValidCreditCard()) 
{
    // Payment logic...
}

// JSON Structure Check
bool isJson = apiResponse.IsValidJson();
```

### 2. High-Performance Manipulation

Perform string operations with minimal memory footprint.

```csharp
string title = "  High Performance Code  ";
// Slug generation (Supports Turkish characters: ı->i, ğ->g)
string slug = title.GenerateSlug(); // "high-performance-code"

string description = "This is a very long text that needs to be shortened.";
// Truncate using Span<T> optimizations
string preview = description.Truncate(20, addEllipsis: true); // "This is a very lo..."
```

### 3. PII Masking & Security

Securely handle sensitive data.

```csharp
string email = "admin@example.com";
Console.WriteLine(email.MaskEmail()); // "ad***@example.com"

// Secure Random Password (CSPRNG)
string secret = GenerationExtensions.RandomPassword(16); 
``` 

## Extension Categories

| Category | Description |
| --- | --- |
| **`ValidationExtensions`** | Validate Email, Credit Card (Luhn), JSON, XML, URL, IP, Palindrome, etc. |
| **`SanitizeExtensions`** | High-perf removal of HTML tags, special chars, digits (Loop-based). |
| **`TruncateExtensions`** | Smart string truncation with ellipsis support (Zero-alloc). |
| **`ManipulationExtensions`** | General manipulation: RemoveWhitespace, SplitLines, Repeat, NormalizeSpaces. |
| **`MaskingExtensions`** | Mask sensitive data like Emails or IDs. |
| **`SearchExtensions`** | `ContainsAny`, `ContainsAll`, `CountOccurrences`, `IsNumeric`. |
| **`TransformationExtensions`** | `GenerateSlug` (Turkish support), `ToInitials`, `Reverse`. |
| **`FormatExtensions`** | `ToSnakeCase`, `ToKebabCase`, `RemoveDiacritics`. |
| **`GenerationExtensions`** | Secure Random String & Password generation. |
| **`ConversionExtensions`** | Safe type conversions (`ToIntOrNull`, `To<T>`). |
| **`CasingExtensions`** | `ToTitleCase`, `ToInvariantLower`, `ToInvariantUpper`. |
| **`PaddingExtensions`** | `PadLeftWith`, `PadRightWith`, `PadBothWith` (Center alignment). |
| **`LengthExtensions`** | Fluent length checks: LongerThan, ShorterThan, IsLengthBetween. |
| **`RegexExtensions`** | Safe Regex matching and extraction with Timeouts. |
| **`DateParsingExtensions`** | Detect if string contains a valid date. |


---

## Contributing

Contributions and suggestions are welcome. Please open an issue or submit a pull request.

---

## License

This project is licensed under the MIT License.

---

  2025 Elmin Alirzayev / Easy Code Tools