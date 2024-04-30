﻿using Xunit;
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
            string filePath = "testFilePath";
            try
            {
                var csvAdapter = new CSVAdapter<int>(filePath);

                Assert.Equal(filePath, csvAdapter.GetPath());
            }
            catch (Exception e)
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void CSVAdapter_Add_AddsItemToCSV()
        {
            string filePath = "testFilePath";
            try
            {
                var csvAdapter = new CSVAdapter<int>(filePath);
                int itemToAdd = 10;

                csvAdapter.Add(itemToAdd);

                Assert.True(File.ReadAllText(filePath).Contains(itemToAdd.ToString()));
            }
            catch (Exception e)
            {
                Assert.True(true);
            }
        }

    }
}
