# Oliver's Bible Browser

A desktop application for searching and exploring Bible scripture, built with C# WPF and SQLite.

## Features

- **Keyword Search** — Query a full Bible dataset by keyword with support for sorting and filtering
- **Multiple Translations** — Browse across 7 different Bible translations using a dropdown selector
- **Book Range Filtering** — Narrow search results to a specific range of books
- **Aggregate Data Views** — View summary statistics broken down by Translation, Book, or Chapter
- **Feature-rich GUI** — Intuitive interface with nested menus and dropdowns for efficient navigation

## Getting Started

1. Open the solution in Visual Studio
2. Build and run the `MSSU-CIS310-MVC` project
3. Type a keyword into the search box and press **Search** or hit **Enter**
4. Use the **Translation** dropdown to switch Bible versions
5. Use the **Book** dropdowns to filter results to a specific range of scripture

## Project Structure

The core logic — event listeners, SQL queries, and filtering — lives in:

```
MSSU-CIS310-MVC/KeywordUI.xaml.cs
```

Models for `Verse`, `Book`, `Translation`, and `Mention` are in the `model/` folder.

## Tech Stack

- C# / WPF (.NET Framework)
- SQLite (`System.Data.SQLite`)
- MVC architecture
