using EventsApp.Logic.Attributes;
using EventsApp.Logic.Adapters;
using EventsApp.Logic.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EventsAppTests_XUnitTest.DatabaseAdapters
{
    public class DataBaseAdapterTests
    {
        private readonly string connectionString = "Server=tcp:iss-events.database.windows.net,1433;Initial Catalog=EventsDB;Persist Security Info=False;User ID={id};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        [Fact]
        public void DataBaseAdapter_Constructor_SetsConnectionString()
        {
            DataBaseAdapter<int> dataBaseAdapter = new DataBaseAdapter<int>(connectionString);

            string actualConnectionString = dataBaseAdapter.ConnectionString();

            Assert.Equal(connectionString, actualConnectionString);
        }

        [Fact]
        public void DataBaseAdapter_Add_CorrectlyAddsItem()
        {
            DataBaseAdapter<EventInfo> dataBaseAdapter = new DataBaseAdapter<EventInfo>(connectionString);
            EventInfo eventInfo = new EventInfo
            {
                GUID = Guid.NewGuid(),
                OrganizerGUID = Guid.NewGuid(),
                EventName = "Test Event",
                Categories = "Test Category",
                Location = "Test Location",
                MaxParticipants = 100,
                Description = "Test Description",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(1),
                BannerURL = "Test Banner URL",
                LogoURL = "Test Logo URL",
                AgeLimit = 18,
                EntryFee = 0.0f
            };

            // Expected return with no DB_Connection
            EventInfo Expected_return = new EventInfo(Guid.Empty);
            dataBaseAdapter.Add(eventInfo);

            EventInfo retrievedEventInfo = dataBaseAdapter.Get(new Identifier(new Dictionary<string, object> { { "GUID", eventInfo.GUID } }));
            Assert.Null(retrievedEventInfo.EventName);
        }

        [Fact]
        public void DataBaseAdapter_Clear_ClearsAllItems()
        {
            DataBaseAdapter<EventInfo> dataBaseAdapter = new DataBaseAdapter<EventInfo>(connectionString);
            EventInfo eventInfo = new EventInfo
            {
                GUID = Guid.NewGuid(),
                OrganizerGUID = Guid.NewGuid(),
                EventName = "Test Event",
                Categories = "Test Category",
                Location = "Test Location",
                MaxParticipants = 100,
                Description = "Test Description",
                StartDate = DateTime.UtcNow,
                EndDate = DateTime.UtcNow.AddDays(1),
                BannerURL = "Test Banner URL",
                LogoURL = "Test Logo URL",
                AgeLimit = 18,
                EntryFee = 0.0f
            };
            dataBaseAdapter.Add(eventInfo);

            dataBaseAdapter.Clear();

            List<EventInfo> allEvents = dataBaseAdapter.GetAll();
            Assert.Empty(allEvents);
        }


    }
}