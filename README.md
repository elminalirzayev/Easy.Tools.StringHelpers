[![Build & Test](https://github.com/elminalirzayev/Easy.Tools.StringHelpers/actions/workflows/build.yml/badge.svg)](https://github.com/elminalirzayev/Easy.Tools.StringHelpers/actions/workflows/build.yml)
[![Build & Release](https://github.com/elminalirzayev/Easy.Tools.StringHelpers/actions/workflows/release.yml/badge.svg)](https://github.com/elminalirzayev/Easy.Tools.StringHelpers/actions/workflows/release.yml)
[![Build & Nuget Publish](https://github.com/elminalirzayev/Easy.Tools.StringHelpers/actions/workflows/nuget.yml/badge.svg)](https://github.com/elminalirzayev/Easy.Tools.StringHelpers/actions/workflows/nuget.yml)
[![Release](https://img.shields.io/github/v/release/elminalirzayev/Easy.Tools.StringHelpers)](https://github.com/elminalirzayev/Easy.Tools.StringHelpers/releases)
[![License](https://img.shields.io/github/license/elminalirzayev/Easy.Tools.StringHelpers)](https://github.com/elminalirzayev/Easy.Tools.StringHelpers/blob/master/LICENSE.txt)
[![NuGet](https://img.shields.io/nuget/v/Easy.Tools.StringHelpers.svg)](https://www.nuget.org/packages/Easy.Tools.StringHelpers)

# Easy.Tools.StringHelpers

A lightweight and extensible .NET library that provides a rich set of string extension methods for everyday development needs.

This package contains categorized string helpers for searching, formatting, validation, sanitization, and more.

---

## Installation

Install via NuGet:
```bash
dotnet add package Easy.Tools.StringHelpers
```
---

##  Features

-  Case-insensitive search and replace
-  String casing (snake_case, kebab-case, title case, camel splitting)
-  HTML stripping and special character removal
-  Validation (palindrome, numeric check, regex match)
-  Digit extraction and counting
-  Repeat, split, trim utilities
-  Random string generation
-  Date parsing support

---

## Usage

```csharp
using Easy.Tools.StringHelpers.Extensions;

string input = "Hello World!";

// Case-insensitive check
bool contains = input.ContainsIgnoreCase("world");

// Snake case conversion
string snake = "HelloWorld".ToSnakeCase(); // hello_world

// Remove whitespace
string clean = "  spaced text  ".RemoveWhitespace(); // "spacedtext"

// Palindrome check
bool isPalindrome = "madam".IsPalindrome(); // true
```

---

## Extension Categories

| Category                 | Description                                |
|--------------------------|--------------------------------------------|
| `SearchExtensions`       | Search, count, replace (ignore case, etc.) |
| `FormatExtensions`       | Snake/kebab case, camel splitting          |
| `ManipulationExtensions` | Whitespace removal, line splitting         |
| `ValidationExtensions`   | Palindrome, numeric, regex                 |
| `GenerationExtensions`   | Random string generator                    |
| `SanitizeExtensions`     | HTML tag and special character removal     |
| `CasingExtensions`       | Title case, invariant case helpers         |
| `LengthExtensions`       | ShorterThan, LongerThan                    |
| `RegexExtensions`        | Match, extract via regex                   |
| `DateParsingExtensions`  | Detect if string contains a valid date     |

---

## License

MIT

---

© 2025 Elmin Alirzayev / Easy Code Tools