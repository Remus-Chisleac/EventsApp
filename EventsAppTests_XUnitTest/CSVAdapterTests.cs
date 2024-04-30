using Xunit;
using EventsApp.Logic.Adapters;
using System.IO;
using System.Collections.Generic;

namespace EventsAppTests_XUnitTest.CSVAdapters
{
    public class CSVAdapterTests
    {
        [Fact]
        public void CSVAdapter_Constructor_SetsFilePath()
        {
            // Arrange
            string filePath = "testFilePath";

            // Act
            var csvAdapter = new CSVAdapter<int>(filePath);

            // Assert
            Assert.Equal(filePath, csvAdapter.GetPath());
        }

        [Fact]
        public void CSVAdapter_Add_AddsItemToCSV()
        {
            // Arrange
            string filePath = "testFilePath";
            var csvAdapter = new CSVAdapter<int>(filePath);
            int itemToAdd = 10;

            // Act
            csvAdapter.Add(itemToAdd);

            // Assert
            Assert.True(File.ReadAllText(filePath).Contains(itemToAdd.ToString()));
        }

        // Add more test methods for other functionalities of the CSVAdapter class
    }
}
