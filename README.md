# Daily Diary Manager

This console application allows users to manage a daily diary text file using C# file manipulation techniques.

## Features

- **Add an Entry**: Append a new entry with specified date and content to the diary file.
- **Delete an Entry**: Remove entries from the diary based on user input date.
- **Count Lines**: Display the total number of entries (lines) in the diary.
- **Read Diary Content**: Display the entire content of the diary file.
- **Exit**: Terminate the application.

## Components

- **Program.cs**: Contains the main method and user interface logic.
- **DailyDiary.cs**: Provides methods for reading, adding, deleting entries, and counting lines in the diary file.
- **Entry.cs**: Defines the `Entry` class representing a diary entry with properties for date and content.
- **DiaryManagerTests**: Contains Xunit tests to verify functionality:
  - `TestReadDiary`: Verifies reading diary content.
  - `AddToDiaryFileTest`: Tests adding new entries and increasing entry count.

## How to Use

1. Clone or download the repository.
2. Build and run the application using Visual Studio or .NET CLI.
3. Follow the on-screen menu options:
   - Choose options 1-4 to add, delete, count, or read diary entries.
   - Option 5 exits the application.
4. Ensure diary file (`MyDiary.txt`) is in the same directory as the executable.

## Error Handling

- Handles exceptions during file operations (e.g., file not found, invalid date format).
- Validates user input to ensure correct format for date entries.

## Stretch Goals

- Implement a search feature to find entries based on date or keyword within content.

## Dependencies

- .NET Core SDK for compiling and running the application.
- Xunit for unit testing.

## Contributors

- [Your Name]

## License

This project is licensed under the MIT License - see the LICENSE file for details.
