using DiaryManager;
using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string diaryFilePath = Path.Combine(Environment.CurrentDirectory, "MyDiary.txt");

        while (true)
        {
            Console.WriteLine("Welcome to Daily Diary Manager");
            Console.WriteLine("1. Add an entry");
            Console.WriteLine("2. Delete an entry");
            Console.WriteLine("3. Count lines in the diary");
            Console.WriteLine("4. Read diary content");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter the date (YYYY-MM-DD): ");
                    string date = Console.ReadLine();

                    Console.Write("Enter the diary entry: ");
                    string content = Console.ReadLine();

                    string[] updatedDiaryContent = DailyDiary.AddEntriesDiary(diaryFilePath, date, content);
                    Console.WriteLine("Entry added to the diary.");

                    // Optionally display the updated diary content
                    Console.WriteLine("Updated diary content:");
                    foreach (string line in updatedDiaryContent)
                    {
                        Console.WriteLine(line);
                    }
                    break;
                case "2":
                    DailyDiary.DeleteEntriesDiary(diaryFilePath);
                    break;
                case "3":
                    DailyDiary.NumberOfLinesDiary(diaryFilePath);
                    break;
                case "4":
                    string diaryContent = DailyDiary.ReadContentDiary(diaryFilePath);
                    Console.WriteLine(diaryContent);
                    break;
                case "5":
                    Console.WriteLine("Exiting application.");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
