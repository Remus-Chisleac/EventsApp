using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsAppTests_XUnitTest
{
    using EventsApp.Logic.Adapters;
    using EventsApp.Logic.Managers;
    using EventsApp.Logic.Entities;
    using Microsoft.Extensions.Logging;

    public class ManagersTests_EventsManager
    {
        private readonly string connectionString = "Server=tcp:iss-events.database.windows.net,1433;Initial Catalog=EventsDB;Persist Security Info=False;User ID={id};Password={password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        [Fact]
        public void GetEvent_NoDBConnetion_ReturnsEventInfo()
        {
            // Arrange
            Guid eventGUID = Guid.NewGuid();
            EventsManager.Initialize(new DataBaseAdapter<EventInfo>(connectionString), new DataBaseAdapter<UserEventRelationInfo>(connectionString));

            // Act
            EventInfo actual = EventsManager.GetEvent(eventGUID);

            // Assert
            Assert.Null(actual.EventName);
        }

        [Fact]
        public void GetAllEvents_NoDBConnetion_ReturnsEvents()
        {
            // Arrange
            List<EventInfo> Expected_return = new List<EventInfo>();
            EventsManager.Initialize(new DataBaseAdapter<EventInfo>(connectionString), new DataBaseAdapter<UserEventRelationInfo>(connectionString));

            // Act
            List<EventInfo> actual = EventsManager.GetAllEvents();

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void IsEventActive_NoDBConnetion_ReturnsFalse()
        {
            // Arrange
            bool Expected_return = false;
            Guid eventGUID = Guid.NewGuid();
            EventsManager.Initialize(new DataBaseAdapter<EventInfo>(connectionString), new DataBaseAdapter<UserEventRelationInfo>(connectionString));

            // Act
            bool actual = EventsManager.IsEventActive(eventGUID);

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void IsOrganizer_NoDBConnetion_ReturnsFalse()
        {
            // Arrange
            bool Expected_return = false;
            Guid userGUID = Guid.NewGuid();
            Guid eventGUID = Guid.NewGuid();
            EventsManager.Initialize(new DataBaseAdapter<EventInfo>(connectionString), new DataBaseAdapter<UserEventRelationInfo>(connectionString));

            // Act
            bool actual = EventsManager.IsOrganizer(userGUID, eventGUID);

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void AddNewEvent_NoDBConnetion_ReturnsEmplyList()
        {
            // Arrange
            List<EventInfo> Expected_return = new List<EventInfo>();
            EventInfo eventInfo = new EventInfo(Guid.NewGuid());
            EventsManager.Initialize(new DataBaseAdapter<EventInfo>(connectionString), new DataBaseAdapter<UserEventRelationInfo>(connectionString));

            // Act
            EventsManager.AddNewEvent(eventInfo);
            List<EventInfo> actual = EventsManager.GetAllEvents();

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void UpdateEvent_NoDBConnetion_ReturnsEmplyList()
        {
            // Arrange
            List<EventInfo> Expected_return = new List<EventInfo>();
            Guid EventId = Guid.NewGuid();
            EventInfo eventInfo = new EventInfo(Guid.NewGuid());
            EventsManager.Initialize(new DataBaseAdapter<EventInfo>(connectionString), new DataBaseAdapter<UserEventRelationInfo>(connectionString));

            // Act
            EventsManager.UpdateEvent(EventId, eventInfo);
            List<EventInfo> actual = EventsManager.GetAllEvents();

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void DeleteEvent_NoDBConnetion_ReturnsEmplyList()
        {
            // Arrange
            List<EventInfo> Expected_return = new List<EventInfo>();
            Guid EventId = Guid.NewGuid();
            EventsManager.Initialize(new DataBaseAdapter<EventInfo>(connectionString), new DataBaseAdapter<UserEventRelationInfo>(connectionString));

            // Act
            EventsManager.DeleteEvent(EventId);
            List<EventInfo> actual = EventsManager.GetAllEvents();

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void IsEventOver_NoDBConnetion_ReturnsTrue()
        {
            // Arrange
            bool Expected_return = true;
            Guid eventGUID = Guid.NewGuid();
            EventsManager.Initialize(new DataBaseAdapter<EventInfo>(connectionString), new DataBaseAdapter<UserEventRelationInfo>(connectionString));

            // Act
            bool actual = EventsManager.IsEventOver(eventGUID);

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void FilterEvents_NoDBConnetion_ReturnsEmplyList()
        {
            // Arrange
            List<EventInfo> Expected_return = new List<EventInfo>();
            EventsManager.Initialize(new DataBaseAdapter<EventInfo>(connectionString), new DataBaseAdapter<UserEventRelationInfo>(connectionString));

            string filterName = "name";
            float filterMaxFee = 0;
            DateTime filterStartDate = DateTime.Now;
            DateTime filterEndDate = DateTime.Now;
            List<string> filterChategories = new List<string>();

            EventsManager.EventFilter filter = new EventsManager.EventFilter(filterName, filterMaxFee, filterStartDate, filterEndDate, filterChategories);

            // Act
            List<EventInfo> actual = EventsManager.FilterEvents(filter);

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void SearchEventByName_NoDBConnetion_ReturnsEmplyList()
        {
            // Arrange
            List<EventInfo> Expected_return = new List<EventInfo>();
            EventsManager.Initialize(new DataBaseAdapter<EventInfo>(connectionString), new DataBaseAdapter<UserEventRelationInfo>(connectionString));

            string eventName = "name";

            // Act
            List<EventInfo> actual = EventsManager.SearchEventByName(eventName);

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void SearchEventByLocation_NoDBConnetion_ReturnsEmplyList()
        {
            // Arrange
            List<EventInfo> Expected_return = new List<EventInfo>();
            EventsManager.Initialize(new DataBaseAdapter<EventInfo>(connectionString), new DataBaseAdapter<UserEventRelationInfo>(connectionString));

            string location = "location";

            // Act
            List<EventInfo> actual = EventsManager.SearchEventByLocation(location);

            // Assert
            Assert.Equal(Expected_return, actual);
        }

        [Fact]
        public void BuyTicket_NoDBConnetion_SetsGoingStatusOfUser()
        {
            // Arrange
            bool Expected_return = false;
            Guid userGUID = Guid.NewGuid();
            Guid eventGUID = Guid.NewGuid();
            string cardHolderName = "";
            string cardNumber = "";
            string cvv = "";
            DateTime expirationDate = DateTime.Now;
            EventsManager.Initialize(new DataBaseAdapter<EventInfo>(connectionString), new DataBaseAdapter<UserEventRelationInfo>(connectionString));
            UsersManager.Initialize(new DataBaseAdapter<UserInfo>(connectionString), new DataBaseAdapter<AdminInfo>(connectionString), new DataBaseAdapter<UserEventRelationInfo>(connectionString));

            // Act
            EventsManager.BuyTicket(userGUID, eventGUID, cardHolderName, cardNumber, cvv, expirationDate);
            bool actual = UsersManager.IsGoing(userGUID, eventGUID);

            // Assert
            Assert.Equal(Expected_return, actual);

        }
    }
}
