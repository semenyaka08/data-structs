# Data Structures: Implementation and Testing

A comprehensive implementation of character list data structures with extensive unit testing coverage.

## 📋 Project Overview

This project contains implementations of two distinct character list data structures:

- **DoublyLinkedCharacterList** — A doubly-linked list implementation
- **ArrayCharacterList** — An array-based dynamic list implementation

The goal is to create custom data structures from scratch and provide comprehensive test coverage using the xUnit testing framework.

## 🎯 Variant Calculation

The variant number is calculated using the formula:
```
Student ID % 4
```

In my case:
```
21 % 4 = 1
```

**Variant 1:**
- Primary implementation: Doubly-linked list
- Secondary implementation: Array-based list

## 🚀 Features

### Common Operations (Both Implementations)
- ✅ **Append** - Add element to the end
- ✅ **Insert** - Insert element at specific index
- ✅ **Delete** - Remove element by index
- ✅ **DeleteAll** - Remove all occurrences of element
- ✅ **GetDataAt** - Retrieve element by index
- ✅ **Clone** - Create independent copy
- ✅ **Reverse** - Reverse list order
- ✅ **FindFirst/FindLast** - Search operations
- ✅ **Clear** - Remove all elements
- ✅ **Extend** - Append another list
- ✅ **Display** - Print list contents

### Performance Optimizations
- **ArrayCharacterList**: Dynamic resizing with capacity doubling
- **DoublyLinkedCharacterList**: Bidirectional traversal optimization

## 🛠️ Building and Testing

### Prerequisites
- .NET SDK 6.0 or higher
- Any text editor or IDE (Visual Studio, VS Code, etc.)

### Setup Instructions

1. **Clone the repository:**
   ```bash
   git clone https://github.com/semenyaka08/data-structs.git
   cd data-structs
   ```

2. **Open the solution:**
   Open `DataStructure.sln` in your preferred IDE or editor.

3. **Restore dependencies:**
   ```bash
   dotnet restore
   ```

4. **Build the project:**
   ```bash
   dotnet build
   ```

5. **Run tests:**
   ```bash
   dotnet test
   ```

### Test Coverage

The project includes comprehensive unit tests covering:
- ✅ All CRUD operations
- ✅ Edge cases and boundary conditions
- ✅ Exception handling
- ✅ Performance optimizations
- ✅ Memory management

## 🔄 Continuous Integration

The project uses GitHub Actions for automated testing on every push and pull request:

```yaml
# Runs on: Ubuntu Latest
# .NET Version: 8.0.x
# Triggers: Push/PR to main branch
```

[![CI](https://github.com/semenyaka08/data-structs/actions/workflows/ci.yml/badge.svg)](https://github.com/semenyaka08/data-structs/actions/workflows/ci.yml)

## 🐛 Failed Tests Reference

During development, a bug was discovered that caused test failures in CI. This demonstrates the value of automated testing:

**🔗 Failed Commit:** [567f747](https://github.com/semenyaka08/data-structs/commit/567f747001bc93ae8fc88ed1d82f2bdb6f9150ab)

The issue was promptly identified and resolved, highlighting the importance of comprehensive test coverage.

## 🏗️ Project Structure

```
📦 data-structs/
├── 📁 .github/workflows/
│   └── ci.yml                    # GitHub Actions CI
├── 📁 DataStructure/
│   ├── BaseList.cs              # Abstract base class
│   ├── ArrayCharacterList.cs    # Array implementation
│   ├── DoublyLinkedCharacterList.cs # Linked list implementation
│   └── Program.cs               # Demo application
├── 📁 DataStructure.Tests/
│   ├── ArrayCharacterListTests.cs
│   └── DoublyLinkedCharacterListTests.cs
├── DataStructure.sln            # Solution file
└── README.md                    # This file
```

**Built with ❤️ using .NET**