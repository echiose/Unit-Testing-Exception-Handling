# Unit Testing Exception Handling

This exercise demonstrates how to test common .NET exception scenarios with C# and NUnit. The `TestApp` project contains small methods that validate input or perform operations, while `TestApp.UnitTests` verifies both successful results and expected exceptions.

## Requirements

- .NET 8 SDK
- Visual Studio 2022, Visual Studio Code, or another .NET-compatible IDE

## Run the tests

From the solution directory:

```powershell
cd 09-Unit-Testing-Exercise-Exception-Handling
dotnet test
```

To run the tests with code coverage collection:

```powershell
dotnet test --collect:"XPlat Code Coverage"
```

## Project structure

```text
09-Unit-Testing-Exercise-Exception-Handling/
├── ExerciseUnitTestingExceptions.sln
├── TestApp/
│   └── Exceptions.cs
└── TestApp.UnitTests/
	└── ExceptionTests.cs
```

## Scenarios covered

| Method | Successful behavior | Exception behavior |
| --- | --- | --- |
| `ArgumentNullReverse` | Reverses a string | Throws `ArgumentNullException` for `null` |
| `ArgumentCalculateDiscount` | Calculates a discounted price | Throws `ArgumentException` when the discount is outside 0-100 |
| `IndexOutOfRangeGetElement` | Returns an array element | Throws `IndexOutOfRangeException` for an invalid index |
| `InvalidOperationPerformSecureOperation` | Confirms a logged-in user | Throws `InvalidOperationException` when the user is not logged in |
| `FormatExceptionParseInt` | Parses an integer | Throws `FormatException` for invalid input |
| `KeyNotFoundFindValueByKey` | Returns a dictionary value | Throws `KeyNotFoundException` for a missing key |
| `OverflowAddNumbers` | Adds two integers | Throws `OverflowException` when checked arithmetic overflows |
| `DivideByZeroDivideNumbers` | Divides two integers | Throws `DivideByZeroException` when the divisor is zero |
| `SumCollectionElements` | Returns the sum of an array | Throws `ArgumentNullException` for `null` and `IndexOutOfRangeException` for an invalid index |
| `GetElementAsNumber` | Reads and parses a dictionary value | Throws `KeyNotFoundException` for a missing key or `FormatException` for invalid numeric text |

## Testing approach

Tests follow the Arrange-Act-Assert pattern. NUnit's `Throws` constraint is used to verify exception types, and selected tests also verify exception messages.
