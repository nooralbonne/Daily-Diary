using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace DiaryManager
{
    public class DailyDiary
    {
        public static string ReadContentDiary(string diaryFileParam)
        {
            try
            {
                string content = File.ReadAllText(diaryFileParam);
                return content;
            }
            catch (Exception ex)
            {
                return $"An error occurred while reading the diary: {ex.Message}";
            }
        }


        public static string[] AddEntriesDiary(string diaryFileParam, string date, string content)
        {
            try
            {
                // Validate date format
                if (!DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
                {
                    Console.WriteLine("Invalid date format. Please enter date in YYYY-MM-DD format.");
                    return new string[0]; // Return an empty array if date format is invalid
                }

                // Append the new entry to the diary file
                string formattedEntry = $"{date}\n{content}\n";
                File.AppendAllText(diaryFileParam, formattedEntry);

                // Read all lines from the diary file and return them
                string[] txtContent = File.ReadAllLines(diaryFileParam);
                return txtContent;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding entries: {ex.Message}");
                return new string[0]; // Return an empty array if an exception occurs
            }
        }




        public static void DeleteEntriesDiary(string diaryFileParam)
        {
            try
            {
                Console.Write("Enter the date (YYYY-MM-DD) of diary entry you want to delete: ");
                string dateToDelete = Console.ReadLine();

                List<Entry> entries = new List<Entry>();

                // Read all entries from the diary file
                using (StreamReader reader = new StreamReader(diaryFileParam))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string date = line.Trim();
                        string content = reader.ReadLine();

                        Entry entry = new Entry(date, content);
                        entries.Add(entry);
                    }
                }

                // Filter out entries with the specified date
                List<Entry> remainingEntries = new List<Entry>();
                foreach (var entry in entries)
                {
                    if (entry.Date != dateToDelete)
                    {
                        remainingEntries.Add(entry);
                    }
                }

                // Write remaining entries back to the diary file
                using (StreamWriter writer = new StreamWriter(diaryFileParam))
                {
                    foreach (Entry entry in remainingEntries)
                    {
                        writer.WriteLine(entry.Date);    // Write date
                        writer.WriteLine(entry.Content); // Write content
                    }
                }

                Console.WriteLine("Entry/entries deleted from the diary.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting entries: {ex.Message}");
            }
        }

        public static void NumberOfLinesDiary(string diaryFileParam)
        {
            try
            {
                // Calculate the number of entries (lines) in the diary file
                int currentCount = CountEntries(diaryFileParam);

                Console.WriteLine($"Total number of entries in the diary is: {currentCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while counting entries: {ex.Message}");
            }
        }

        private static int CountEntries(string diaryFilePath)
        {
            try
            {
                int entryCount = 0;

                // Read all lines and count entries
                using (StreamReader reader = new StreamReader(diaryFilePath))
                {
                    while (reader.ReadLine() != null)
                    {
                        entryCount++;
                    }
                }

                return entryCount; // Assuming each entry occupies two lines (date and content)
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error counting entries in diary: {ex.Message}");
                return 0;
            }
        }
    }
}
