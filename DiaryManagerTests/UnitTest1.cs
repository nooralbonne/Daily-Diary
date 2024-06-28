using DiaryManager;
using System;
using System.IO;
using Xunit;

namespace DiaryManagerTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestReadDiary()
        {
            // Arrange
            string diaryFilePath = Path.Combine(Environment.CurrentDirectory, "MyDiary.txt");

            // Act
            string result = DailyDiary.ReadContentDiary(diaryFilePath);

            // Assert
            string textContent = File.ReadAllText(diaryFilePath);
            Assert.Equal(result, textContent);
        }

        [Fact]
        public void AddToDiaryFileTest()
        {
            // Arrange 
            string diaryFilePath = Path.Combine(Environment.CurrentDirectory, "MyDiary.txt");
            int initialLineCount = File.ReadAllLines(diaryFilePath).Length;
            Entry entryToAdd = new Entry("2023-06-11", "New Line");

            // Act
            string[] updatedDiaryContent = DailyDiary.AddEntriesDiary(diaryFilePath, entryToAdd.Date, entryToAdd.Content);

            // Assert
            int finalLineCount = File.ReadAllLines(diaryFilePath).Length;

            Assert.True(finalLineCount > initialLineCount);
        }
    }
}
